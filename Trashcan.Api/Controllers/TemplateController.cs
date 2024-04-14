using Microsoft.AspNetCore.Mvc;
using Trashcan.Domain.Dto.RubricDto;
using Trashcan.Domain.Dto.TemplateDto;
using Trashcan.Domain.Entity;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;

namespace Trashcan.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TemplateController : Controller
{
    private readonly ITemplateService _templateService;

    public TemplateController(ITemplateService templateService)
    {
        _templateService = templateService;
    }

    /// <summary>
    /// Создание нового шаблона.
    /// </summary>
    /// <param name="dto"> Создоваемый шаблон. </param>
    /// <returns> Создоваемый шаблон. </returns>
    [HttpPost]
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
    /// Вывод всех шаблонов.
    /// </summary>
    /// <returns> Массив со всеми шаблонами. </returns>
    [HttpGet]
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
    /// Обновление данных шаблона.
    /// </summary>
    /// <param name="dto"> Данные шаблона. </param>
    /// <returns> Шаблон с обновленными данными. </returns>
    [HttpPut]
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
    /// Удаление существующего шаблона.
    /// </summary>
    /// <param name="id"> Id удаляемого щаблона. </param>
    /// <returns> Удаляемый шаблон. </returns>
    [HttpDelete]
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