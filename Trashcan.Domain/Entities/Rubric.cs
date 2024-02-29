﻿using Trashcan.Domain.Entities.BaseEntity;

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
		public char Name { get; set; }

		/// <summary>
		/// Краткое описание пункта каталога происшествий.
		/// </summary>
		public char Description { get; set; }

		/// <summary>
		/// Ссылка хранения изображения темы.
		/// </summary>
		public char Image { get; set; }
	}
}
