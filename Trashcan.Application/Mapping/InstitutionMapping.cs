using AutoMapper;
using Trashcan.Domain.Dto.InstitutionDto;
using Trashcan.Domain.Entity;

namespace Trashcan.Application.Mapping;

public class InstitutionMapping : Profile
{
    public InstitutionMapping()
    {
        CreateMap<Institution, InstitutionDto>().ReverseMap();
    }
}