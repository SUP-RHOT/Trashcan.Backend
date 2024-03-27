using Microsoft.AspNetCore.Mvc;
using Trashcan.Application.Services;
using Trashcan.Domain.Dto.ActorDTO;
using Trashcan.Domain.Result;

namespace Trashcan.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ActorController : ControllerBase
{
    private readonly ActorService _actorService;

    public ActorController(ActorService actorService)
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
}