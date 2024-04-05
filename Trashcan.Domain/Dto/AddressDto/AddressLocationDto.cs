namespace Trashcan.Domain.Dto.AddressDto
{
    public class AddressLocationDto
    {
        /// <summary>
        /// Город, в котором произошло происшествие.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Название улицы, на которой произошло происшествие.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Номер дома на улице, в котором произошло происшествие.
        /// </summary>
        public string House { get; set; }
    }
}
