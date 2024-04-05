using Trashcan.Domain.Dto.EventDto;
using Trashcan.Domain.Result;

namespace Trashcan.Domain.Interfaces.Services;

/// <summary>
/// Обработка происшествий.
/// </summary>
public interface IEventService
{
    /// <summary>
    /// Получение всех происшествий.
    /// </summary>
    /// <returns> Массив происшествий. </returns>
    Task<CollectionResult<EventDto>> GetEventsAsync();

    /// <summary>
    /// Получение конкретного происшествия по id.
    /// </summary>
    /// <param name="id"> id конкретного происшествия. </param>
    /// <returns> Конкретное происшествие. </returns>
    Task<BaseResult<EventDto>> GetEventByIdAsync(int id);

    /// <summary>
    /// Создание нового происшествия.
    /// </summary>
    /// <param name="dto"> Создаваемое происшествие. </param>
    /// <param name="addressId"> Идентификатор адреса. </param>
    /// <returns> Создаваемое происшествие. </returns>
    Task<BaseResult<EventDto>> CreateEventAsync(EventCreateDto dto, int addressId);

    /// <summary>
    /// Удаление происшествия по id.
    /// </summary>
    /// <param name="id"> id удаляемого происшествия. </param>
    /// <returns> Удаляемое происшествие. </returns>
    Task<BaseResult<EventDto>> DeleteEventAsync(int id);

    /// <summary>
    /// Получение всех происшествий актера.
    /// </summary>
    /// <param name="actorId"> Id актера. </param>
    /// <returns> Массив происшествий. </returns>
    Task<CollectionResult<EventDto>> GetActorEventsAsync(int actorId);
}