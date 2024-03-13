using Trashcan.Domain.Dto.TemplateDto;
using Trashcan.Domain.Result;

namespace Trashcan.Domain.Interfaces.Services;

/// <summary>
/// Обработка шаблонов сообщений.
/// </summary>
public interface ITemplateService
{
    /// <summary>
    /// Получение всех шаблонов сообщений.
    /// </summary>
    /// <returns> Массив шаблонов сообщений. </returns>
    Task<CollectionResult<TemplateDto>> GetTemplatesAsync();

    /// <summary>
    /// Получение конкретного шаблона сообщений по id.
    /// </summary>
    /// <param name="id"> id конкретного шаблона сообщений. </param>
    /// <returns> Конкретный шаблон сообщений. </returns>
    Task<BaseResult<TemplateDto>> GetTemplateByIdAsync(int id);

    /// <summary>
    /// Создание нового шаблона сообщений.
    /// </summary>
    /// <param name="dto"> Создаваемый шаблон сообщений. </param>
    /// <returns> Создаваемый шаблон сообщений. </returns>
    Task<BaseResult<TemplateDto>> CreateTemplateAsync(TemplateDto dto);

    /// <summary>
    /// Удаление шаблона сообщений по id.
    /// </summary>
    /// <param name="id"> id удаляемого шаблона сообщений. </param>
    /// <returns> Удаляемый шаблон сообщений. </returns>
    Task<BaseResult<TemplateDto>> DeleteTemplateAsync(int id);

    /// <summary>
    /// Обновление данных конкретного шаблона сообщений.
    /// </summary>
    /// <param name="dto"> Объект с обновленными данными. </param>
    /// <returns> Шаблон сообщений с обновленными данными. </returns>
    Task<BaseResult<TemplateDto>> UpdateTemplateAsync(TemplateDto dto);
}