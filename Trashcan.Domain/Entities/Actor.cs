using Trashcan.Domain.Entities.BaseEntity;


namespace Trashcan.Domain.Entity
{
	/// <summary>
	/// Актёр, действующий субъект.
	/// </summary>
	public class Actor : IBaseEntity<int>
	{
		/// <summary>
		/// Уникальный идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Фамилия субъекта.
		/// </summary>
		public char Lastname { get; set; }

		/// <summary>
		/// Имя субъекта.
		/// </summary>
		public char Firstname { get; set; }

		/// <summary>
		/// Отчество субъекта.
		/// </summary>
		public char Secondname { get; set; }

		/// <summary>
		/// Телефон субъекта.
		/// </summary>
		public char PhoneNumber { get; set; }

		/// <summary>
		/// E-mail субъекта.
		/// </summary>
		public char Email { get; set; }

		/// <summary>
		/// Город, в котором проживает субъект.
		/// </summary>
		public char City { get; set; }

		/// <summary>
		/// Улица, на которой проживает субъект.
		/// </summary>
		public char Street { get; set; }

		/// <summary>
		/// Дом, в котором проживает субъект.
		/// </summary>
		public char House { get; set; }

		/// <summary>
		/// Квартира, в которой проживает субъект.
		/// </summary>
		public char Apartament { get; set; }

		/// <summary>
		/// Логин субъекта.
		/// </summary>
		public char Login { get; set; }

		/// <summary>
		/// Пароль субъекта.
		/// </summary>
		public char Password { get; set; }

		/// <summary>
		/// Статус субъекта.
		/// </summary>
		public bool Status { get; set; }

		/// <summary>
		/// Согласие на получение рассылки новостей о проекте.
		/// </summary>
		public bool Mailing { get; set; }

		/// <summary>
		/// Сушность Role.
		/// </summary>
		public Role Role { get; set; }

		/// <summary>
		/// Cсылка на поле Id в сущности Role.
		/// </summary>
		public int RoleId { get; set; }
	}
}
