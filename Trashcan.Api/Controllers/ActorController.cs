using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trashcan.Application.Services;
using Trashcan.Domain.Dto.ActorDTO;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;

namespace Trashcan.Api.Controllers;

[Authorize(Roles = "Пользователь")]
[ApiController]
[Route("api/v1/[controller]")]
public class ActorController : ControllerBase
{
    private readonly IActorService _actorService;

    public ActorController(IActorService actorService)
    {
        _actorService = actorService;
    }

    [Route("refreshToken")]
    [HttpGet]
    public async Task<ActionResult<BaseResult<ActorDto>>> RefreshToken(int id)
    {
        var response = await _actorService.GetActorByIdAsync(id);
        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }

    [Route("id")]
    [HttpGet]
    public async Task<ActionResult<BaseResult<ActorDto>>> GetActorById(int id)
    {
        var response = await _actorService.GetActorByIdAsync(id);
        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
}