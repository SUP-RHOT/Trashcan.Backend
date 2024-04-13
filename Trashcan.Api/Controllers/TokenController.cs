using Microsoft.AspNetCore.Mvc;
using Trashcan.Domain.Dto.AuthToken;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;

namespace Trashcan.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TokenController : ControllerBase
{
    private readonly ITokenService _tokenService;

    public TokenController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    /// <summary>
    /// Обновление Jwt-токенов. 
    /// </summary>
    /// <param name="tokenDto"> Jwt-токены (Access и Refresh) </param>
    /// <returns> Обновленные токены. </returns>
    [HttpPost]
    [Route("refresh")]
    public async Task<ActionResult<BaseResult<TokenDto>>> RefreshToken([FromBody] TokenDto tokenDto)
    {
        var response = await _tokenService.RefreshToken(tokenDto);
        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
}