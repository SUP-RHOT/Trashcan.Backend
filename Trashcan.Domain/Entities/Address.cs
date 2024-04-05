using Trashcan.Domain.Entities.BaseEntity;

namespace Trashcan.Domain.Entity
{
    /// <summary>
    /// Адрес происшествия.
    /// </summary>
    public class Address : IBaseEntity<int>
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
        /// Город, в котором произошло происшествие.
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// Название улицы, на которой произошло происшествие.
        /// </summary>
        public string? Street { get; set; }

        /// <summary>
        /// Номер дома на улице, в котором произошло происшествие.
        /// </summary>
        public string? House { get; set; }
    }
}