using Trashcan.Domain.Dto.ActorDTO;
using Trashcan.Domain.Dto.AuthToken;
using Trashcan.Domain.Result;

namespace Trashcan.Domain.Interfaces.Services;

/// <summary>
/// Сервис для регистрации/авторизации пользователей.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Регистрация пользователя.
    /// </summary>
    /// <param name="dto"> Создаваемый пользователь. </param>
    /// <returns></returns>
    Task<BaseResult<RegisterActorDto>> Register(RegisterActorDto dto);
    
    /// <summary>
    /// Авторизация пользователя.
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<BaseResult<TokenDto>> Login(LoginActorDto dto);
}