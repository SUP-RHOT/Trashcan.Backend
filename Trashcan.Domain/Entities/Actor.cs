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
		public string Lastname { get; set; }

		/// <summary>
		/// Имя субъекта.
		/// </summary>
		public string Firstname { get; set; }

		/// <summary>
		/// Отчество субъекта.
		/// </summary>
		public string? Secondname { get; set; }

		/// <summary>
		/// Телефон субъекта.
		/// </summary>
		public string PhoneNumber { get; set; }

		/// <summary>
		/// E-mail субъекта.
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Город, в котором проживает субъект.
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// Улица, на которой проживает субъект.
		/// </summary>
		public string Street { get; set; }

		/// <summary>
		/// Дом, в котором проживает субъект.
		/// </summary>
		public string House { get; set; }

		/// <summary>
		/// Квартира, в которой проживает субъект.
		/// </summary>
		public string Apartament { get; set; }

		/// <summary>
		/// Логин субъекта.
		/// </summary>
		public string Login { get; set; }

		/// <summary>
		/// Пароль субъекта.
		/// </summary>
		public string Password { get; set; }

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
