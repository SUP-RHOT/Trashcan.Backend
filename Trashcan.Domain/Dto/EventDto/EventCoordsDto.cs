using Trashcan.Domain.Dto.AddressDto;

namespace Trashcan.Domain.Dto.EventDto
{
    public class EventCoordsDto
    {
        public EventCreateDto EventCreateDto { get; set; }
        public AddressCoordsDto AddressDto { get; set; }
    }
}
