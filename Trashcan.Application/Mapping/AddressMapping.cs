using AutoMapper;
using Trashcan.Domain.Dto.AddressDto;
using Trashcan.Domain.Entity;

namespace Trashcan.Application.Mapping;

public class AddressMapping : Profile
{
    public AddressMapping()
    {
        CreateMap<Address, AddressDto>().ReverseMap();
    }
}