using Trashcan.Domain.Dto.AddressDto;

namespace Trashcan.Domain.Dto.EventDto
{
    public class EventLocationDto
    {
        public EventCreateDto EventCreateDto { get; set; }
        public AddressLocationDto AddressDto { get; set; }
    }
}
