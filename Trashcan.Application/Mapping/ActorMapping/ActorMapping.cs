using AutoMapper;
using Trashcan.Domain.Dto.ActorDTO;
using Trashcan.Domain.Entity;

namespace Trashcan.Application.Mapping.ActorMapping;

public class ActorMapping : Profile 
{
    public ActorMapping()
    {
        CreateMap<Actor, ActorDto>().ReverseMap();
    }
}