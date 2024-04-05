using AutoMapper;
using Trashcan.Domain.Dto.AddressDto;
using Trashcan.Domain.Entity;

namespace Trashcan.Application.Mapping.AddressMapping
{
    public class AddressLocationMapping : Profile
    {
        public AddressLocationMapping()
        {
            CreateMap<Address, AddressLocationDto>().ReverseMap();
        }
    }
}