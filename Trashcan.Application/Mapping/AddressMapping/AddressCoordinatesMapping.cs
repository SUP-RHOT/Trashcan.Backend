using AutoMapper;
using Trashcan.Domain.Dto.AddressDto;
using Trashcan.Domain.Entity;

namespace Trashcan.Application.Mapping.AddressMapping
{
    public class AddressCoordinatesMapping : Profile
    {
        public AddressCoordinatesMapping()
        {
            CreateMap<Address, AddressCoordsDto>().ReverseMap();
        }
    }
}
