using Trashcan.Domain.Dto.InstitutionDto;
using Trashcan.Domain.Result;

namespace Trashcan.Domain.Interfaces.Services;

/// <summary>
/// Обработка инстанций.
/// </summary>
public interface IInstitutionService
{
    /// <summary>
    /// Получение всех инстанций.
    /// </summary>
    /// <returns> Массив инстанций. </returns>
    Task<CollectionResult<InstitutionDto>> GetInstitutionsAsync();

    /// <summary>
    /// Получение конкретной инстанции по id.
    /// </summary>
    /// <param name="id"> id конкретной инстанции. </param>
    /// <returns> Конкретная инстанция. </returns>
    Task<BaseResult<InstitutionDto>> GetInstitutionByIdAsync(int id);

    /// <summary>
    /// Создание новой инстанции.
    /// </summary>
    /// <param name="dto"> Создаваемая инстанция. </param>
    /// <returns> Создаваемая инстанция. </returns>
    Task<BaseResult<InstitutionDto>> CreateInstitutionAsync(InstitutionDto dto);

    /// <summary>
    /// Удаление инстанции по id.
    /// </summary>
    /// <param name="id"> id удаляемой инстанции. </param>
    /// <returns> Удаляемая инстанция. </returns>
    Task<BaseResult<InstitutionDto>> DeleteInstitutionAsync(int id);

    /// <summary>
    /// Обновление данных конкретной инстанции.
    /// </summary>
    /// <param name="dto"> Объект с обновленными данными. </param>
    /// <returns> Инстанция с обновленными данными. </returns>
    Task<BaseResult<InstitutionDto>> UpdateInstitutionAsync(InstitutionDto dto);
}