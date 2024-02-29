using Trashcan.Domain.Entities.BaseEntity;

namespace Trashcan.Domain.Entity
{
	/// <summary>
	/// Происшествие, которое будет описывать субъект.
	/// </summary>
	public class Event : IBaseEntity<int>
	{
		/// <summary>
		/// Уникальный идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Статус сообщения: черновик или готовое.
		/// </summary>
		public bool Status { get; set; }

		/// <summary>
		/// Тема сообщения.
		/// </summary>
		public char TypeMessage { get; set; }

		/// <summary>
		/// Текст субъекта, описывающий проблему.
		/// </summary>
		public char TextMessage { get; set; }

		/// <summary>
		/// Ссылка хранения фотографии событии.
		/// </summary>
		public string Photo { get; set; }

		/// <summary>
		/// Дата создания сообщения.
		/// </summary>
		public DateTime Date { get; set; }

		/// <summary>
		/// Результат решения проблемы.
		/// </summary>
		public bool Result { get; set; }
	}
}
