using Microsoft.AspNetCore.Mvc;
using Trashcan.Domain.Dto.AddressBaseDto;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;

namespace Trashcan.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddresBaseController : ControllerBase
{
    private readonly IAddressBaseService _addressBaseService;

    public AddresBaseController(IAddressBaseService addressBaseService)
    {
        _addressBaseService = addressBaseService;
    }

    /// <summary>
    /// Создание нового шаблона.
    /// </summary>
    /// <param name="dto"> Создоваемый шаблон. </param>
    /// <returns> Создоваемый шаблон. </returns>
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<BaseResult<AddressBaseDto>>> CreateAddressBase([FromBody] AddressBaseDto dto)
    {
        var response = await _addressBaseService.CreateBaseAddressAsync(dto);

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
    [Route("getAll")]
    public async Task<ActionResult<CollectionResult<AddressBaseDto>>> GetAddressBase()
    {
        var response = await _addressBaseService.GetBaseAddressesAsync();

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
    [Route("update")]
    public async Task<ActionResult<BaseResult<AddressBaseDto>>> UpdateAddressBase([FromBody] AddressBaseDto dto)
    {
        var response = await _addressBaseService.UpdateBaseAddressAsync(dto);

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
    [Route("delete")]
    public async Task<ActionResult<BaseResult<AddressBaseDto>>> DeleteAddressBase(int id)
    {
        var response = await _addressBaseService.DeleteBaseAddressAsync(id);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
    }
}