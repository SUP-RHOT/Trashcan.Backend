using AutoMapper;
using Trashcan.Domain.Dto.EventDto;
using Trashcan.Domain.Entity;

namespace Trashcan.Application.Mapping.EventMapping;

public class EventMapping : Profile
{
    public EventMapping()
    {
        CreateMap<Event, EventDto>().ReverseMap();
    }
}