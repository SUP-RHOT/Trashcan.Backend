using Trashcan.Domain.Entities.BaseEntity;

namespace Trashcan.Domain.Entity
{
	/// <summary>
	/// База данных адресов, где будут заложены все адреса и определены координаты, где работает наш проект.
	/// </summary>
	public class AddressBase : IBaseEntity<int>
	{
		/// <summary>
		/// Уникальный идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Координаты долготы на карте.
		/// </summary>
		public float? Longitude { get; set; }

		/// <summary>
		/// Координаты широты на карте.
		/// </summary>
		public float? Width { get; set; }

		/// <summary>
		/// Название города, в котором работает проект.
		/// </summary>
		public string? City { get; set; }

		/// <summary>
		/// Название улицы, которая входит в зону работы проекта.
		/// </summary>
		public string? Street { get; set; }

		/// <summary>
		/// Номер дома на улице, входящей в зону работы проекта.
		/// </summary>
		public string? House { get; set; }
	}
}
