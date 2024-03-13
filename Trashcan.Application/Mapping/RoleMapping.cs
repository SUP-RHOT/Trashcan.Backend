using AutoMapper;
using Trashcan.Domain.Dto.RoleDto;
using Trashcan.Domain.Entity;

namespace Trashcan.Application.Mapping;

public class RoleMapping : Profile
{
    public RoleMapping()
    {
        CreateMap<Role, RoleDto>().ReverseMap();
    }
}
