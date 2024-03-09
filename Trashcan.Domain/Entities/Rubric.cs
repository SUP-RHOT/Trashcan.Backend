using Trashcan.Domain.Entities.BaseEntity;

namespace Trashcan.Domain.Entity
{
	/// <summary>
	/// Каталог или рубрикатор происшествий, инцидентов.
	/// </summary>
	public class Rubric : IBaseEntity<int>
	{
		/// <summary>
		/// Уникальный идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название пункта каталога происшествий.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Краткое описание пункта каталога происшествий.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Ссылка хранения изображения темы.
		/// </summary>
		public string Image { get; set; }

		/// <summary>
		/// Сущность Institution.
		/// </summary>
		public Institution Institution { get; set; }

		/// <summary>
		/// Ссылка на поле Id в сущности Institution.
		/// </summary>
		public int InstitutionId { get; set; }
	}
}
