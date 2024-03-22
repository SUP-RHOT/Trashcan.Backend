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
    /// <returns> Создаваемое происшествие. </returns>
    Task<BaseResult<EventDto>> CreateEventAsync(EventDto dto);

    /// <summary>
    /// Удаление происшествия по id.
    /// </summary>
    /// <param name="id"> id удаляемого происшествия. </param>
    /// <returns> Удаляемое происшествие. </returns>
    Task<BaseResult<EventDto>> DeleteEventAsync(int id);

    /// <summary>
    /// Обновление данных конкретного происшествия.
    /// </summary>
    /// <param name="dto"> Объект с обновленными данными. </param>
    /// <returns> Происшествие с обновленными данными. </returns>
    Task<BaseResult<EventDto>> UpdateEventAsync(EventDto dto);

    /// <summary>
    /// Получение всех происшествий актера.
    /// </summary>
    /// <param name="actorId"> Id актера. </param>
    /// <returns> Массив происшествий. </returns>
    Task<CollectionResult<EventDto>> GetActorEventsAsync(int actorId);
}