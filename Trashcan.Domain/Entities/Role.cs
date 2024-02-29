using Trashcan.Domain.Entities.BaseEntity;

namespace Trashcan.Domain.Entity
{
	/// <summary>
	/// Роль действующего субъекта.
	/// </summary>
	public class Role : IBaseEntity<int>
	{
		/// <summary>
		/// Уникальный идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название роли субъекта.
		/// </summary>
		public char Name { get; set; }
	}
}
