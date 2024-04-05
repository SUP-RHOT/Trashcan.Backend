using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trashcan.Application.Services;
using Trashcan.Domain.Dto.ActorDTO;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;

namespace Trashcan.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class ActorController : ControllerBase
{
    private readonly IActorService _actorService;

    public ActorController(IActorService actorService)
    {
        _actorService = actorService;
    }

    //[Route("actor")]
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