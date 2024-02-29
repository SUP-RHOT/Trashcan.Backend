using Trashcan.Domain.Entities.BaseEntity;

namespace Trashcan.Domain.Entity
{
	/// <summary>
	/// Шаблон сообщения, для обращения в соответствующую происшествию инстанцию.
	/// </summary>
	public class Template : IBaseEntity<int>
	{
		/// <summary>
		/// Уникальный идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название шаблона сообщения, создаваемого для конкретной инстанции.
		/// </summary>
		public char Name { get; set; }

		/// <summary>
		/// Текст шаблона сообщения, создаваемого для конкретной инстанции.
		/// </summary>
		public char Text { get; set; }
	}
}
