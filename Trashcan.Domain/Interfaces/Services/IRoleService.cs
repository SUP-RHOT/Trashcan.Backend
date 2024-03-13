using Trashcan.Domain.Dto.RoleDto;
using Trashcan.Domain.Result;

namespace Trashcan.Domain.Interfaces.Services;

/// <summary>
/// Обработка ролей субъектов.
/// </summary>
public interface IRoleService
{
    /// <summary>
    /// Получение всех ролей субъектов.
    /// </summary>
    /// <returns> Массив ролей субъектов. </returns>
    Task<CollectionResult<RoleDto>> GetRolesAsync();

    /// <summary>
    /// Получение конкретной роли по id.
    /// </summary>
    /// <param name="id"> id конкретной роли. </param>
    /// <returns> Конкретная роль. </returns>
    Task<BaseResult<RoleDto>> GetRoleByIdAsync(int id);

    /// <summary>
    /// Создание новой роли субъекта.
    /// </summary>
    /// <param name="dto"> Создаваемая роль. </param>
    /// <returns> Создаваемая роль. </returns>
    Task<BaseResult<RoleDto>> CreateRoleAsync(RoleDto dto);

    /// <summary>
    /// Удаление роли субъекта по id.
    /// </summary>
    /// <param name="id"> id удаляемой роли. </param>
    /// <returns> Удаляемая роль. </returns>
    Task<BaseResult<RoleDto>> DeleteRoleAsync(int id);

    /// <summary>
    /// Обновление данных конкретной роли субъекта.
    /// </summary>
    /// <param name="dto"> Объект с обновленными данными. </param>
    /// <returns> Роль субъекта с обновленными данными. </returns>
    Task<BaseResult<RoleDto>> UpdateRoleAsync(RoleDto dto);
}