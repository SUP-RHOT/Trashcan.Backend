using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Trashcan.Application.Resources;
using Trashcan.Domain.Dto.AuthToken;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;
using Trashcan.Domain.Settings;

namespace Trashcan.Application.Services;

public class TokenService : ITokenService
{
    private readonly string _jwtKey;
    private readonly string _issuer;
    private readonly string _audiece;

    public TokenService(IOptions<JwtSettings> options)
    {
        _jwtKey = options.Value.JwtKey;
        _issuer = options.Value.Issuer;
        _audiece = options.Value.Audience;
    }

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
        //var token =
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    public string GenerateRefreshToken()
    {
        var randomNumbers = new byte[32];
        using var randomNumberGenerator = RandomNumberGenerator.Create();
        randomNumberGenerator.GetBytes(randomNumbers);
        return Convert.ToBase64String(randomNumbers);
    }

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

    public Task<BaseResult<TokenDto>> RefreshToken(TokenDto dto)
    {
        var accessToken = dto.AccessToken;
        var refreshToken = dto.RefreshToken;
    }
}