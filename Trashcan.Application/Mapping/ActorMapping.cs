using AutoMapper;
using Trashcan.Domain.Dto.ActorDTO;
using Trashcan.Domain.Entity;

namespace Trashcan.Application.Mapping;

public class ActorMapping : Profile 
{
    public ActorMapping()
    {
        CreateMap<Actor, ActorDto>().ReverseMap();
    }
}