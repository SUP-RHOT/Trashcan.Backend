using Trashcan.Domain.Dto.RubricDto;
using Trashcan.Domain.Result;

namespace Trashcan.Domain.Interfaces.Services;

/// <summary>
/// Обработка рубрикаторов происшествий.
/// </summary>
public interface IRubricService
{
    /// <summary>
    /// Получение всех рубрикаторов происшествий.
    /// </summary>
    /// <returns> Массив рубрикаторов происшествий. </returns>
    Task<CollectionResult<RubricDto>> GetRubricsAsync();

    /// <summary>
    /// Получение конкретного рубрикатора происшествий по id.
    /// </summary>
    /// <param name="id"> id конкретного рубрикатора происшествий. </param>
    /// <returns> Конкретный рубрикатор происшествий. </returns>
    Task<BaseResult<RubricDto>> GetRubricByIdAsync(int id);

    /// <summary>
    /// Создание нового рубрикатора происшествий.
    /// </summary>
    /// <param name="dto"> Создаваемый рубрикатор происшествий. </param>
    /// <returns> Создаваемый рубрикатор происшествий. </returns>
    Task<BaseResult<RubricDto>> CreateRubricAsync(RubricDto dto);

    /// <summary>
    /// Удаление рубрикатора происшествий по id.
    /// </summary>
    /// <param name="id"> id удаляемого рубрикатора происшествий. </param>
    /// <returns> Удаляемый рубрикатор происшествий. </returns>
    Task<BaseResult<RubricDto>> DeleteRubricAsync(int id);

    /// <summary>
    /// Обновление данных конкретного рубрикатора происшествий.
    /// </summary>
    /// <param name="dto"> Объект с обновленными данными. </param>
    /// <returns> Рубрикатор происшествий с обновленными данными. </returns>
    Task<BaseResult<RubricDto>> UpdateRubricAsync(RubricDto dto);
}