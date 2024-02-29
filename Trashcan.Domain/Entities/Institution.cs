using Trashcan.Domain.Entities.BaseEntity;

namespace Trashcan.Domain.Entity
{
	/// <summary>
	/// Инстанция, для которой может создаваться сообщение.
	/// </summary>
	public class Institution : IBaseEntity<int>
	{
		/// <summary>
		/// Уникальный идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название инстанции, для которой создается сообщение.
		/// </summary>
		public char Name { get; set; }

		/// <summary>
		/// Город, в котором действует инстанция.
		/// </summary>
		public char City { get; set; }

		/// <summary>
		/// Район города, в котором действует инстанция.
		/// </summary>
		public char District { get; set; }

		/// <summary>
		/// Описание конкретной инстанции.
		/// </summary>
		public char Description { get; set; }
	}
}
