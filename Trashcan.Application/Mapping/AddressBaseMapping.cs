using AutoMapper;
using Trashcan.Domain.Dto.AddressBaseDto;
using Trashcan.Domain.Entity;

namespace Trashcan.Application.Mapping;

public class AddressBaseMapping : Profile
{
    public AddressBaseMapping()
    {
        CreateMap<AddressBase, AddressBaseDto>().ReverseMap();
    }
}