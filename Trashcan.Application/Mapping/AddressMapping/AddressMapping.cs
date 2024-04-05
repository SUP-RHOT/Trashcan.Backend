using AutoMapper;
using Trashcan.Domain.Dto.AddressDto;
using Trashcan.Domain.Entity;

namespace Trashcan.Application.Mapping.AddressMapping;

public class AddressMapping : Profile
{
    public AddressMapping()
    {
        CreateMap<Address, AddressDto>().ReverseMap();
    }
}