using AutoMapper;
using Trashcan.Domain.Dto.TemplateDto;
using Trashcan.Domain.Entity;

namespace Trashcan.Application.Mapping;

public class TemplateMapping : Profile
{
    public TemplateMapping()
    {
        CreateMap<Template, TemplateDto>().ReverseMap();
    }
}
