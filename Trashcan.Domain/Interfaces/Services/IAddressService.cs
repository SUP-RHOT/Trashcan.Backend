using Trashcan.Domain.Dto.AddressDto;
using Trashcan.Domain.Result;

namespace Trashcan.Domain.Interfaces.Services;

/// <summary>
/// Обработка происшествий.
/// </summary>
public interface IAddressService
{
    /// <summary>
    /// Получение всех происшествий.
    /// </summary>
    /// <returns> Массив происшествий. </returns>
    Task<CollectionResult<AddressDto>> GetAddressesAsync();

    /// <summary>
    /// Получение конкретного происшествия по id.
    /// </summary>
    /// <param name="id"> id конкретного происшествия. </param>
    /// <returns> Конкретное происшествие. </returns>
    Task<BaseResult<AddressDto>> GetAddressByIdAsync(int id);

    /// <summary>
    /// Создание нового происшествия.
    /// </summary>
    /// <param name="dto"> Создаваемое происшествие. </param>
    /// <returns> Создаваемое происшествие. </returns>
    Task<BaseResult<AddressDto>> CreateAddressAsync(AddressDto dto);

    /// <summary>
    /// Удаление происшествия по id.
    /// </summary>
    /// <param name="id"> id удаляемого происшествия. </param>
    /// <returns> Удаляемое происшествие. </returns>
    Task<BaseResult<AddressDto>> DeleteAddressAsync(int id);

    /// <summary>
    /// Обновление данных конкретного происшествия.
    /// </summary>
    /// <param name="dto"> Объект с обновленными данными. </param>
    /// <returns> Происшествие с обновленными данными. </returns>
    Task<BaseResult<AddressDto>> UpdateAddressAsync(AddressDto dto);

    /// <summary>
    /// Получение конкретного происшествия по координатам.
    /// </summary>
    /// <param name="longitude"> Координаты долготы на карте. </param>
    /// <param name="width"> Координаты широты на карте. </param>
    /// <returns> Конкретное происшествие. </returns>
    Task<BaseResult<AddressDto>> GetAddressByCoordinates(float longitude, float width);

    /// <summary>
    /// Получение конкретного происшествия по местоположению.
    /// </summary>
    /// <param name="city"> Город, в котором произошло происшествие. </param>
    /// <param name="street"> Название улицы, на которой произошло происшествие. </param>
    /// <param name="house"> Номер дома на улице, в котором произошло происшествие. </param>
    /// <returns> Конкретное происшествие. </returns>
    Task<BaseResult<AddressDto>> GetAddressByLocation(string city, string street, string house);
}