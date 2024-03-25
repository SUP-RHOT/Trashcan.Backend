using AutoMapper;
using Trashcan.Domain.Dto.ActorDTO;
using Trashcan.Domain.Entity;

namespace Trashcan.Application.Mapping.ActorMapping;

public class RegisterActorMapping : Profile
{
    public RegisterActorMapping() 
    { 
        CreateMap<Actor, RegisterActorDto>().ReverseMap();
    }
}