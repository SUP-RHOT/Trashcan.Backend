using Azure;
using Microsoft.AspNetCore.Mvc;
using Trashcan.Domain.Dto.ActorDTO;
using Trashcan.Domain.Dto.AddressDto;
using Trashcan.Domain.Dto.AuthToken;
using Trashcan.Domain.Dto.EventDto;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;

namespace Trashcan.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IAddressService _addressService;
        public EventController(IEventService eventService, IAddressService addressService)
        {
            _eventService = eventService;
            _addressService = addressService;
        }

        [Route("getAll")]
        [HttpGet]
        public async Task<ActionResult<CollectionResult<EventInfoDto>>> GetAllEvents()
        {
            var responce = await _eventService.GetEventsAsync();

            if (responce.IsSuccess)
            {
                return Ok(responce);
            }

            return BadRequest(responce);
        }

        [HttpPost("createByCoords")]
        public async Task<ActionResult<BaseResult<EventDto>>> CreateEventByCoords([FromBody] EventCoordsDto eventDto)
        {
            var addressResponce = await _addressService.CreateAddressByCoordinates(eventDto.AddressDto);

            if (addressResponce.IsSuccess)
            {
                var eventResponce = await _eventService.CreateEventAsync(eventDto.EventCreateDto, addressResponce.Data);

                if (eventResponce.IsSuccess)
                {
                    return Ok(eventResponce);
                }

                return BadRequest(eventResponce);
            }

            return BadRequest(addressResponce);
        }

        [HttpPost("createByLocation")]
        public async Task<ActionResult<BaseResult<EventDto>>> CreateEventByLocation([FromBody] EventLocationDto eventDto)
        {
            var addressResponce = _addressService.CreateAddressByLocation(eventDto.AddressDto).Result;

            if (addressResponce.IsSuccess)
            {
                var eventResponce = await _eventService.CreateEventAsync(eventDto.EventCreateDto, addressResponce.Data);

                if (eventResponce.IsSuccess)
                {
                    return Ok(eventResponce);
                }

                return BadRequest(eventResponce);
            }

            return BadRequest(addressResponce);
        }

        [HttpDelete("deleteEvent")]
        public async Task<ActionResult<BaseResult<EventDto>>> DeleteEvent(int Id)
        {
            var response = await _eventService.DeleteEventAsync(Id);

            if (response.IsSuccess)
            {
                return Ok(response);
                
            }

            return BadRequest(response);
        }
    }
}
