using Trashcan.Domain.Dto.AddressBaseDto;
using Trashcan.Domain.Result;

namespace Trashcan.Domain.Interfaces.Services;

/// <summary>
/// Обработка базы данных адресов.
/// </summary>
public interface IAddressBaseService
{
    /// <summary>
    /// Получение всех базовых адресов.
    /// </summary>
    /// <returns> Массив базовых адресов. </returns>
    Task<CollectionResult<AddressBaseDto>> GetBaseAddressesAsync();

    /// <summary>
    /// Получение конкретного базового адреса по id.
    /// </summary>
    /// <param name="id"> id конкретного базового адреса. </param>
    /// <returns> Конкретный базовый адрес. </returns>
    Task<BaseResult<AddressBaseDto>> GetBaseAddressByIdAsync(int id);

    /// <summary>
    /// Создание нового базового адреса.
    /// </summary>
    /// <param name="dto"> Создаваемый базовый адрес. </param>
    /// <returns> Создаваемый базовый адрес. </returns>
    Task<BaseResult<AddressBaseDto>> CreateBaseAddressAsync(AddressBaseDto dto);

    /// <summary>
    /// Удаление базового адреса по id.
    /// </summary>
    /// <param name="id"> id удаляемого базового адреса. </param>
    /// <returns> Удаляемый базовый адрес. </returns>
    Task<BaseResult<AddressBaseDto>> DeleteBaseAddressAsync(int id);

    /// <summary>
    /// Обновление данных конкретного базового адреса.
    /// </summary>
    /// <param name="dto"> Объект с обновленными данными. </param>
    /// <returns> Базовый адрес с обновленными данными. </returns>
    Task<BaseResult<AddressBaseDto>> UpdateBaseAddressAsync(AddressBaseDto dto);
}