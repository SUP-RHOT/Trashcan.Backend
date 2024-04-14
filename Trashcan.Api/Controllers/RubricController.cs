using Microsoft.AspNetCore.Mvc;
using Trashcan.Domain.Dto.RubricDto;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;

namespace Trashcan.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RubricController : ControllerBase
{
    private readonly IRubricService _rubricService;

    public RubricController(IRubricService rubricService)
    {
        _rubricService = rubricService;
    }

    /// <summary>
    /// Создание новой рубрики.
    /// </summary>
    /// <param name="dto"> Создоваемая рубрика. </param>
    /// <returns> Создоваемая рубрика. </returns>
    [HttpPost]
    public async Task<ActionResult<BaseResult<RubricDto>>> CreateRubric(RubricDto dto)
    {
        var response = await _rubricService.CreateRubricAsync(dto);

        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
    
    /// <summary>
    /// Вывод всех рубрик.
    /// </summary>
    /// <returns> Массив со всеми рубриками. </returns>
    [HttpGet]
    public async Task<ActionResult<CollectionResult<RubricDto>>> GetRubric()
    {
        var response = await _rubricService.GetRubricsAsync();

        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }

    /// <summary>
    /// Обновление данных рубрики.
    /// </summary>
    /// <param name="dto"> Данные рубрики. </param>
    /// <returns> Рубрика с обновленными данными. </returns>
    [HttpPut]
    public async Task<ActionResult<BaseResult<RubricDto>>> UpdateRubric(RubricDto dto)
    {
        var response = await _rubricService.UpdateRubricAsync(dto);

        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
    
    /// <summary>
    /// Удаление существующей рубрики.
    /// </summary>
    /// <param name="id"> Id удаляемой рубрики. </param>
    /// <returns> Удаляемая рубрика. </returns>
    [HttpDelete]
    public async Task<ActionResult<BaseResult<RubricDto>>> DeleteRubric(int id)
    {
        var response = await _rubricService.DeleteRubricAsync(id);

        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
}