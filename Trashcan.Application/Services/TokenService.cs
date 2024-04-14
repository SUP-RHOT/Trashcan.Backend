using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Trashcan.Application.Resources;
using Trashcan.Domain.Dto.AuthToken;
using Trashcan.Domain.Entity;
using Trashcan.Domain.Enum;
using Trashcan.Domain.Interfaces.BaseRepository;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;
using Trashcan.Domain.Settings;

namespace Trashcan.Application.Services;

/// <inheritdoc />
public class TokenService : ITokenService
{
    private readonly IBaseRepository<Actor> _actorRepository;
    private readonly ILogger _logger;
    private readonly string _jwtKey;
    private readonly string _issuer;
    private readonly string _audiece;

    public TokenService(IOptions<JwtSettings> options, IBaseRepository<Actor> actorRepository, ILogger logger)
    {
        _actorRepository = actorRepository;
        _logger = logger;
        _jwtKey = options.Value.JwtKey;
        _issuer = options.Value.Issuer;
        _audiece = options.Value.Audience;
    }

    /// <inheritdoc />
    public string GenerateAccessToken(IEnumerable<Claim> claims)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
        var creadentialns = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var securityToken = new JwtSecurityToken(
            _issuer,
            _audiece,
            claims,
            null,
            DateTime.UtcNow.AddMinutes(10),
            creadentialns
            );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    /// <inheritdoc />
    public string GenerateRefreshToken()
    {
        var randomNumbers = new byte[32];
        using var randomNumberGenerator = RandomNumberGenerator.Create();
        randomNumberGenerator.GetBytes(randomNumbers);

        return Convert.ToBase64String(randomNumbers);
    }

    /// <inheritdoc />
    public ClaimsPrincipal GetPrincipalFromExpiredToken(string accessToken)
    {
        var tokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey)),
            ValidateLifetime = true
        };

        var tokenHendler = new JwtSecurityTokenHandler();
        var claimsPrincipal = tokenHendler.ValidateToken(accessToken, tokenValidationParameters, out var securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException(ErrorMessage.InvalidToken);
        }

        return claimsPrincipal;
    }

    /// <inheritdoc />
    public async Task<BaseResult<TokenDto>> RefreshToken(TokenDto dto)
    {

        var claimsPrincipal = GetPrincipalFromExpiredToken(dto.AccessToken);
        var actorName = claimsPrincipal.Identity?.Name;

        try
        {
            var actor = await _actorRepository
                .GetAll()
                .Include(x => x.ActorToken)
                .FirstOrDefaultAsync(x => x.Login == actorName);

            if (actor == null || actor.ActorToken.RefreshToken != dto.RefreshToken ||
                actor.ActorToken.RefreshTokenExpiryTime < DateTime.Now)
            {
                _logger.Warning(ErrorMessage.InvalidClientRequest, actor);
                return new BaseResult<TokenDto>()
                {
                    ErrorMassage = ErrorMessage.InvalidClientRequest
                };
            }

            var accessToken = GenerateAccessToken(claimsPrincipal.Claims);
            var refreshToken = GenerateRefreshToken();

            actor.ActorToken.RefreshToken = refreshToken;
            await _actorRepository.UpdateAsync(actor);

            return new BaseResult<TokenDto>()
            {
                Data = new TokenDto(accessToken, refreshToken, actor.Id)
            };
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            return new BaseResult<TokenDto>()
            {
                ErrorMassage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCode.InternalServerError
            };
        }
    }
}