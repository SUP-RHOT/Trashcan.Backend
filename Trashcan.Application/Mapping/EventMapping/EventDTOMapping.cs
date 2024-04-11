using AutoMapper;
using Trashcan.Domain.Dto.EventDto;
using Trashcan.Domain.Entity;

namespace Trashcan.Application.Mapping.EventMapping;

public class EventDTOMapping : Profile
{
    public EventDTOMapping()
    {
        CreateMap<EventDto, Event>().ReverseMap();
    }
}