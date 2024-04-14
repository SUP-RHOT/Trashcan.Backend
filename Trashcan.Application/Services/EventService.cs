using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        private readonly IBaseRepository<Address> _addressRepository;
        private readonly IBaseRepository<Actor> _actorRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;

        public EventService
            (
            IBaseRepository<Event> repository,
            IBaseRepository<Template> templateRepository,
            IBaseRepository<Rubric> rubricRepository,
            IBaseRepository<Address> addressRepository,
            IBaseRepository<Actor> actorRepository,
            ILogger logger,
            IMapper mapper,
            IMailService mailService
            )
        {
            _eventRepository = repository;
            _logger = logger;
            _mapper = mapper;
            _templateRepository = templateRepository;
            _rubricRepository = rubricRepository;
            _addressRepository = addressRepository;
            _actorRepository = actorRepository;
            _mailService = mailService;
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
                var rubric = _rubricRepository.GetAll()
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

                var actor = _actorRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == dto.ActorId).Result;

                await _mailService.SendAsync(actor.Email, "SUPЕRHOT", "Событие успешно создано.");

                return new BaseResult<EventDto>()
                {
                    Data = _mapper.Map<EventDto>(_eventRepository.GetAll().OrderBy(item => item.Id).Last())
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

                var actor = _actorRepository.GetAll()
                   .FirstOrDefaultAsync(x => x.Id == eventToDelete.ActorId).Result;

                await _mailService.SendAsync(actor.Email, "SUPЕRHOT", "Событие успешно удалено.");

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
        public async Task<CollectionResult<EventInfoDto>> GetEventsAsync()
        {
            try
            {
                var events = await _eventRepository.GetAll()
                    .Select(x => _mapper.Map<EventDto>(x))
                    .ToArrayAsync();

                if (!events.Any())
                {
                    _logger.Warning(ErrorMessage.DataNotFount, events.Length);
                    return new CollectionResult<EventInfoDto>()
                    {
                        ErrorMassage = ErrorMessage.DataNotFount,
                        ErrorCode = (int)ErrorCode.DataNotFount
                    };
                }

                return GetEventsInfo(events);
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return new CollectionResult<EventInfoDto>()
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

        /// <summary>
        /// Получить часть информации об событии.
        /// </summary>
        /// <param name="dto"> Событие. </param>
        /// <returns> Информация по событию. </returns>
        private async Task<BaseResult<EventInfoDto>> GetEventInfo(EventDto dto)
        {
            var address = await _addressRepository.GetAll()
                   .FirstOrDefaultAsync(x => x.Id == dto.AddressId);

            return new BaseResult<EventInfoDto>()
            {
                Data = new EventInfoDto(
                    dto.Id,
                    dto.Status,
                    dto.TypeMessage,
                    dto.TextMessage,
                    dto.Photo,
                    dto.Date,
                    dto.Result,
                    address
                )
            };
        }

        /// <summary>
        /// Получить информацию по событиям.
        /// </summary>
        /// <param name="events"> События для дополнения информацией. </param>
        /// <returns> События с дополнительной информацией. </returns>
        private CollectionResult<EventInfoDto> GetEventsInfo(EventDto[] events)
        {
            var eventsInfo = new List<EventInfoDto>();

            foreach (var eventEl in events)
                eventsInfo.Add(GetEventInfo(eventEl).Result.Data);

            return new CollectionResult<EventInfoDto>()
            {
                Data = eventsInfo.ToArray(),
                Count = eventsInfo.Count()
            };
        }
    }
}