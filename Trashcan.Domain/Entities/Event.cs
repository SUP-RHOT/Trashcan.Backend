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

		/// <summary>
		/// Сущность Actor.
		/// </summary>
		public Actor Actor { get; set; }

		/// <summary>
		/// Ссылка на поле Id в сущности Actor.
		/// </summary>
		public int ActorId { get; set; }

		/// <summary>
		/// Сущность Rubric.
		/// </summary>
		public Rubric Rubric { get; set; }

		/// <summary>
		/// Ссылка на поле Id в сущности Rubric.
		/// </summary>
		public int RubricId { get; set; }

		/// <summary>
		/// Сущность Address.
		/// </summary>
		public Address Address { get; set; }

		/// <summary>
		/// Ссылка на поле Id в сущности Address.
		/// </summary>
		public int AddressId { get; set; }

		/// <summary>
		/// Сущность Template.
		/// </summary>
		public Template Template { get; set; }

		/// <summary>
		/// Ссылка на поле Id в сущности Template.
		/// </summary>
		public int TemplateId { get; set; }
	}
}
