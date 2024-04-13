using Microsoft.AspNetCore.Mvc;
using Trashcan.Domain.Dto.RubricDto;
using Trashcan.Domain.Dto.TemplateDto;
using Trashcan.Domain.Entity;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;

namespace Trashcan.Api.Controllers;

public class TemplateController : Controller
{
    private readonly ITemplateService _templateService;

    public TemplateController(ITemplateService templateService)
    {
        _templateService = templateService;
    }

    /// <summary>
    /// Создание новой рубрики.
    /// </summary>
    /// <param name="dto"> Создоваемая рубрика. </param>
    /// <returns> Создоваемая рубрика. </returns>
    public async Task<ActionResult<BaseResult<TemplateDto>>> CreateTemplate(TemplateDto dto)
    {
        var response = await _templateService.CreateTemplateAsync(dto);

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
    public async Task<ActionResult<CollectionResult<TemplateDto>>> GetTemplate()
    {
        var response = await _templateService.GetTemplatesAsync();

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
    public async Task<ActionResult<BaseResult<TemplateDto>>> UpdateTemplate(TemplateDto dto)
    {
        var response = await _templateService.UpdateTemplateAsync(dto);

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
    public async Task<ActionResult<BaseResult<TemplateDto>>> DeleteTemplate(int id)
    {
        var response = await _templateService.DeleteTemplateAsync(id);

        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
}