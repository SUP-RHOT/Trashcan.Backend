using AutoMapper;
using Trashcan.Domain.Dto.EventDto;
using Trashcan.Domain.Entity;

namespace Trashcan.Application.Mapping.EventMapping;

public class EventDataDTOMapping : Profile
{
    public EventDataDTOMapping()
    {
        CreateMap<Event, EventDataDTO>().ReverseMap();
    }
}