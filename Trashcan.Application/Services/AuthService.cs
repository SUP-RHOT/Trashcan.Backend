using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Trashcan.Application.Resources;
using Trashcan.Domain.Dto.ActorDTO;
using Trashcan.Domain.Dto.AuthToken;
using Trashcan.Domain.Entities.BaseEntity;
using Trashcan.Domain.Entity;
using Trashcan.Domain.Enum;
using Trashcan.Domain.Interfaces.BaseRepository;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;

namespace Trashcan.Application.Services;

public class AuthService : IAuthService
{
    private readonly IBaseRepository<Actor> _actorRepository;
    private readonly IBaseRepository<ActorToken> _actorTokenRepository;
    private readonly ITokenService _tokenService;
    
    private readonly ILogger _logger;
    private readonly IMapper _mapping;

    public AuthService(
        IBaseRepository<Actor> actorRepository, 
        ILogger logger, 
        IMapper mapping, 
        IBaseRepository<ActorToken> actorTokenRepository, 
        ITokenService tokenService
        )
    {
        _actorRepository = actorRepository;
        _logger = logger;
        _mapping = mapping;
        _actorTokenRepository = actorTokenRepository;
        _tokenService = tokenService;
    }

    public async Task<BaseResult<RegisterActorDto>> Register(RegisterActorDto dto)
    {
        try
        {
            var actor = await _actorRepository.GetAll().FirstOrDefaultAsync(x => x.Login == dto.Login);
            if (actor != null)
            {
                _logger.Warning(ErrorMessage.ActorAlreadyExists, dto.Login);
                return new BaseResult<RegisterActorDto>()
                {
                    ErrorMassage = ErrorMessage.ActorAlreadyExists,
                    ErrorCode = (int)ErrorCode.ActorAlreadyExists
                };
            }

            actor = _mapping.Map<Actor>(dto);

            await _actorRepository.CreateAsync(actor);

            return new BaseResult<RegisterActorDto>()
            {
                Data = dto
            };
            
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            return new BaseResult<RegisterActorDto>()
            {
                ErrorMassage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCode.InternalServerError
            };
        }
    }

    public async Task<BaseResult<TokenDto>> Login(LoginActorDto dto)
    {
        try
        {
            var actor = await _actorRepository.GetAll().FirstOrDefaultAsync(x => x.Login == dto.Login);
            if (actor == null)
            {
                _logger.Warning(ErrorMessage.DataNotFount, dto.Login);
                return new BaseResult<TokenDto>()
                {
                    ErrorMassage = ErrorMessage.DataNotFount,
                    ErrorCode = (int)ErrorCode.DataNotFount
                };
            }
            
            if (!IsVerifyPassword(actor.Password, dto.Password))
            {
                return new BaseResult<TokenDto>()
                {
                    ErrorMassage = ErrorMessage.InvalidPassword,
                    ErrorCode = (int)ErrorCode.InvalidPassword
                };
            }

            var actorToken = await _actorTokenRepository.GetAll().FirstOrDefaultAsync(x => x.ActorId == actor.Id);

            var claimes = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, actor.Login),
                new Claim(ClaimTypes.Role, "User")
            };
            
            var accessTocen = _tokenService.GenerateAccessToken(claimes);
            var refreshToken = _tokenService.GenerateRefreshToken();
            
            
            if (actorToken == null)
            {
                actorToken = new ActorToken()
                {
                    ActorId = actor.Id,
                    RefreshToken = refreshToken,
                    RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7)
                };
                await _actorTokenRepository.CreateAsync(actorToken);
            }
            else
            {
                actorToken.RefreshToken = refreshToken;
                actorToken.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            }


            return new BaseResult<TokenDto>()
            {
                Data = new TokenDto(accessTocen, refreshToken)
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
    
    private string HashPassword(string password)
    {
        var salt = "Sup-rHot";
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password + salt));
        return BitConverter.ToString(bytes).ToLower();
    }

    private bool IsVerifyPassword(string ActorPasswordHash, string actorPasswors)
    {
        var hash = HashPassword(actorPasswors);
        return ActorPasswordHash == hash;
    }
}