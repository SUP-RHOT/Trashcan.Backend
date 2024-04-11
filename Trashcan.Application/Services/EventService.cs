using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Serilog;
using Trashcan.Application.Resources;
using Trashcan.Domain.Dto.EventDto;
using Trashcan.Domain.Entity;
using Trashcan.Domain.Enum;
using Trashcan.Domain.Interfaces.BaseRepository;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;

namespace Trashcan.Application.Services
{
    /// <inheritdoc />
    public class EventService : IEventService
    {
        private readonly IBaseRepository<Event> _eventRepository;
        private readonly IBaseRepository<Rubric> _rubricRepository;
        private readonly IBaseRepository<Template> _templateRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public EventService
            (
            IBaseRepository<Event> repository, 
            IBaseRepository<Template> templateRepository, 
            IBaseRepository<Rubric> rubricRepository,  
            ILogger logger, 
            IMapper mapper
            )
        {
            _eventRepository = repository;
            _logger = logger;
            _mapper = mapper;
            _templateRepository = templateRepository;
            _rubricRepository = rubricRepository;
        }

        /// <inheritdoc />
        public async Task<BaseResult<EventDto>> CreateEventAsync(EventCreateDto dto, int addressId)
        {
            try
            {
                if (dto == null)
                {
                    return new BaseResult<EventDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }
                var rubric  = _rubricRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Name == dto.RubricName).Result;

                if (rubric == null)
                {
                    return new BaseResult<EventDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                var template = _templateRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Name == dto.TemplateName).Result;


                if (dto == null)
                {
                    return new BaseResult<EventDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                var eventData = new EventDataDTO
                (
                    dto.Status,
                    dto.TypeMessage,
                    dto.TextMessage,
                    dto.Photo,
                    dto.Date,
                    dto.Result,
                    dto.ActorId,
                    rubric.Id,
                    addressId,
                    template.Id
                );

                await _eventRepository.CreateAsync(_mapper.Map<Event>(eventData));

                return new BaseResult<EventDto>()
                {
                    Data = _mapper.Map <EventDto> (_eventRepository.GetAll().OrderBy(item => item.Id).Last())
                };

            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new BaseResult<EventDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }

        /// <inheritdoc />
        public async Task<BaseResult<EventDto>> DeleteEventAsync(int id)
        {
            try
            {
                var eventToDelete = await _eventRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (eventToDelete == null)
                {
                    _logger.Warning(ErrorMessage.DataNotFount, id);
                    return new BaseResult<EventDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                await _eventRepository.RemoveAsync(eventToDelete);

                return new BaseResult<EventDto>()
                {
                    Data = _mapper.Map<EventDto>(eventToDelete)
                };
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new BaseResult<EventDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }

        /// <inheritdoc />
        public async Task<BaseResult<EventDto>> GetEventByIdAsync(int id)
        {
            try
            {
                var eventToGet = await _eventRepository.GetAll()
                    .Select(x => _mapper.Map<EventDto>(x))
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (eventToGet == null)
                {
                    _logger.Warning(ErrorMessage.DataNotFount, id);
                    return new BaseResult<EventDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                return new BaseResult<EventDto>()
                {
                    Data = eventToGet
                };
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new BaseResult<EventDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }

        /// <inheritdoc />
        public async Task<CollectionResult<EventDto>> GetEventsAsync()
        {
            try
            {
                var events = await _eventRepository.GetAll()
                    .Select(x => _mapper.Map<EventDto>(x))
                    .ToArrayAsync();

                if (!events.Any())
                {
                    _logger.Warning(ErrorMessage.DataNotFount, events.Length);
                    return new CollectionResult<EventDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                return new CollectionResult<EventDto>()
                {
                    Data = events,
                    Count = events.Length
                };
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new CollectionResult<EventDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }

        /// <inheritdoc />
        public async Task<CollectionResult<EventDto>> GetActorEventsAsync(int actorId)
        {
            try
            {
                var events = await _eventRepository.GetAll()
                    .Select(x => _mapper.Map<EventDto>(x))
                    .Where(x => x.ActorId == actorId)
                    .ToArrayAsync();

                if (!events.Any())
                {
                    _logger.Warning(ErrorMessage.DataNotFount, events.Length);
                    return new CollectionResult<EventDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                return new CollectionResult<EventDto>()
                {
                    Data = events,
                    Count = events.Length
                };
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new CollectionResult<EventDto>()
                {
                    ErrorMassage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCode.InternalServerError
                };
            }
        }
    }
}