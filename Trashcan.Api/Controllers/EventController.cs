using Microsoft.AspNetCore.Mvc;
using Trashcan.Domain.Dto.AuthToken;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;

namespace Trashcan.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        ///?
        public async Task<ActionResult<CollectionResult<TokenDto>>> GetAllEvents()
        {
            var responce = await _eventService.GetEventsAsync();

            if (responce.IsSuccess)
            {
                return Ok(responce);
            }

            return BadRequest(responce);
        }
    }
}
