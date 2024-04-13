using Microsoft.AspNetCore.Mvc;
using Trashcan.Domain.Dto.ActorDTO;
using Trashcan.Domain.Dto.AuthToken;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;

namespace Trashcan.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    /// <summary>
    /// Регистрация дользователя.
    /// </summary>
    /// <param name="dto"> Данные для регистрации. </param>
    /// <returns> Результат регистрации. </returns>
    [HttpPost("register")]
    public async Task<ActionResult<BaseResult<string>>> Register([FromBody] RegisterActorDto dto)
    {
        var response = await _authService.Register(dto);
        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
    
    /// <summary>
    /// Авторизация пользователяю
    /// </summary>
    /// <param name="dto"> Днные для авторизации. </param>
    /// <returns> Jwt-токены (Access и Refresh).  </returns>
    [HttpPost("login")]
    public async Task<ActionResult<BaseResult<TokenDto>>> Login([FromBody] LoginActorDto dto)
    {
        var response = await _authService.Login(dto);

        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(Response);
    }
}