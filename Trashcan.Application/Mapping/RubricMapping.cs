using AutoMapper;
using Trashcan.Domain.Dto.RubricDto;
using Trashcan.Domain.Entity;

namespace Trashcan.Application.Mapping;

public class RubricMapping : Profile
{
    public RubricMapping()
    {
        CreateMap<Rubric, RubricDto>().ReverseMap();
    }
}
