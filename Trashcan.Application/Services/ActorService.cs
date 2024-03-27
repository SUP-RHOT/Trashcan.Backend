using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Trashcan.Application.Resources;
using Trashcan.Domain.Dto.ActorDTO;
using Trashcan.Domain.Entity;
using Trashcan.Domain.Enum;
using Trashcan.Domain.Interfaces.BaseRepository;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;

namespace Trashcan.Application.Services;

public class ActorService : IActorService
{
    private readonly IBaseRepository<Actor> _repository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public ActorService(IBaseRepository<Actor> repository, ILogger logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<CollectionResult<ActorDto>> GetActorAsync()
    {
        try
        {
            var actors = await _repository.GetAll()
                .Select(x => _mapper.Map<ActorDto>(x))
                .ToArrayAsync();

            if (!actors.Any())
            {
                _logger.Warning(ErrorMessage.DataNotFount, actors.Length);
                return new CollectionResult<ActorDto>()
                {
                    ErrorMassage = ErrorMessage.DataNotFount,
                    ErrorCode = (int)ErrorCode.DataNotFount
                };
            }

            return new CollectionResult<ActorDto>()
            {
                Data = actors,
                Count = actors.Length
            };
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            return new CollectionResult<ActorDto>()
            {
                ErrorMassage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCode.InternalServerError
            };
        }
    }

    public async Task<BaseResult<ActorDto>> GetActorByIdAsync(int id)
    {
        try
        {
            var actor = await _repository.GetAll()
                .Select(x => _mapper.Map<ActorDto>(x))
                .FirstOrDefaultAsync(x => x.Id == id);

            if (actor == null)
            {
                _logger.Warning(ErrorMessage.DataNotFount, id);
                return new BaseResult<ActorDto>()
                {
                    ErrorMassage = ErrorMessage.DataNotFount,
                    ErrorCode = (int)ErrorCode.DataNotFount
                };
            }

            return new BaseResult<ActorDto>()
            {
                Data = actor
            };
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            return new BaseResult<ActorDto>()
            {
                ErrorMassage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCode.InternalServerError
            };
        }


    }

    public async Task<BaseResult<ActorDto>> CreateActorAsync(ActorDto? dto)
    {
        try
        {
            if (dto == null)
            {
                return new BaseResult<ActorDto>()
                {
                    ErrorMassage = ErrorMessage.DataNotFount,
                    ErrorCode = (int)ErrorCode.DataNotFount
                };
            }

            await _repository.CreateAsync(_mapper.Map<Actor>(dto));

            return new BaseResult<ActorDto>()
            {
                Data = dto
            };

        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            return new BaseResult<ActorDto>()
            {
                ErrorMassage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCode.InternalServerError
            };
        }
    }

    public async Task<BaseResult<ActorDto>> DeleteActorAsync(int id)
    {
        try
        {
            var actor = await _repository.GetAll()
                .FirstOrDefaultAsync(x => x.Id == id);
            
            if (actor == null)
            {
                _logger.Warning(ErrorMessage.DataNotFount, id);
                return new BaseResult<ActorDto>()
                {
                    ErrorMassage = ErrorMessage.DataNotFount,
                    ErrorCode = (int)ErrorCode.DataNotFount
                };
            }

            await _repository.RemoveAsync(actor);

            return new BaseResult<ActorDto>()
            {
                Data = _mapper.Map<ActorDto>(actor)
            };
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            return new BaseResult<ActorDto>()
            {
                ErrorMassage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCode.InternalServerError
            };
        }
    }

    public async Task<BaseResult<ActorDto>> UpdateActorAsync(ActorDto dto)
    {
        try
        {
            var actor = await _repository.GetAll()
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (actor == null)
            {
                _logger.Warning(ErrorMessage.DataNotFount, dto.Id);
                return new BaseResult<ActorDto>()
                {
                    ErrorMassage = ErrorMessage.DataNotFount,
                    ErrorCode = (int)ErrorCode.DataNotFount
                };
            }
            
            await _repository.UpdateAsync(_mapper.Map<Actor>(dto));

            return new BaseResult<ActorDto>()
            {
                Data = dto
            };
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            return new BaseResult<ActorDto>()
            {
                ErrorMassage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCode.InternalServerError
            };
        }
    }
}


