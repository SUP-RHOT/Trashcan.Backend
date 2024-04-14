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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Получение пользователя по Id.
    /// </summary>
    /// <param name="id">Id пользователя.</param>
    /// <returns> Пользователь. </returns>
    [Route("getActor")]
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

    /// <summary>
    /// Обновление данных о пользователе.
    /// </summary>
    /// <param name="dto"> Обновленные данные. </param>
    /// <returns> Пользователь с обновленными данными. </returns>
    [Route("updateActor")]
    [HttpPut]
    public async Task<ActionResult<BaseResult<ActorDto>>> UpdateActor(ActorDto dto)
    {
        var response = await _actorService.UpdateActorAsync(dto);
        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }

    /// <summary>
    /// Получение списка всех пользователей.
    /// </summary>
    /// <returns> Массив со всеми пользователями. </returns>
    [Route("getActors")]
    [HttpGet]
    public async Task<ActionResult<CollectionResult<ActorDto>>> GetActor()
    {
        var response = await _actorService.GetActorAsync();
        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
}