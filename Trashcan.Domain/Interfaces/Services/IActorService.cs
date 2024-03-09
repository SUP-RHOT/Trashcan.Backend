using Trashcan.Domain.Dto.ActorDTO;
using Trashcan.Domain.Result;

namespace Trashcan.Domain.Interfaces.Services;

/// <summary>
/// Обработка актеров.
/// </summary>
public interface IActorService
{
    /// <summary>
    /// Получение всех актеров.
    /// </summary>
    /// <returns> Массив актеров. </returns>
    Task<CollectionResult<ActorDto>> GetActorAsync();

    /// <summary>
    /// Получение конкретного актера по id.
    /// </summary>
    /// <param name="id"> id конкретного актера. </param>
    /// <returns> Конкретный актер. </returns>
    Task<BaseResult<ActorDto>> GetActorByIdAsync(int id);

    /// <summary>
    /// Создание нового артера.
    /// </summary>
    /// <param name="dto"> Создаваемый актер. </param>
    /// <returns> Создаваемый актер. </returns>
    Task<BaseResult<ActorDto>> CreateActorAsync(ActorDto dto);
    
    /// <summary>
    /// Удаление актера по id.
    /// </summary>
    /// <param name="id"> id удаляемого актера. </param>
    /// <returns> Удаляемый актер. </returns>
    Task<BaseResult<ActorDto>> DeleteActorAsync(int id);

    /// <summary>
    /// Обновление данных конкретного актера.
    /// </summary>
    /// <param name="dto"> Объект с обновленными данными. </param>
    /// <returns> Актер с обновленными данными. </returns>
    Task<BaseResult<ActorDto>> UpdateActorAsync(ActorDto dto);
}