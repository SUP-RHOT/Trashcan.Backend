using Microsoft.EntityFrameworkCore;
using Serilog;
using Trashcan.Application.Resources;
using Trashcan.DAL.Repositories;
using Trashcan.Domain.Dto.ActorDTO;
using Trashcan.Domain.Entity;
using Trashcan.Domain.Enum;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;

namespace Trashcan.Application.Services;

public class ActorService : IActorService
{
    private readonly BaseRepository<Actor> _repository;
    private readonly ILogger _logger;

    public ActorService(BaseRepository<Actor> repository, ILogger logger)
    {
        _repository = repository;
        _logger = logger;
    }
    
    public async Task<CollectionResult<ActorDTO>> GetActor()
    {
        try
        {
            var actors = await _repository.GetAll()
                .Select(x => new ActorDTO
                (
                    x.Id,
                    x.Lastname,
                    x.Firstname,
                    x.Secondname,
                    x.PhoneNumber,
                    x.Email,
                    x.City,
                    x.Street,
                    x.House,
                    x.Apartament
                ))
                .ToArrayAsync();

            if (!actors.Any())
            {
                _logger.Warning(ErrorMessage.DataNotFount, actors.Length);
                return new CollectionResult<ActorDTO>()
                {
                    ErrorMassage = ErrorMessage.DataNotFount,
                    ErrorCode = (int)ErrorCode.DataNotFount
                };
            }

            return new CollectionResult<ActorDTO>()
            {
                Data = actors,
                Count = actors.Length
            };
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            return new CollectionResult<ActorDTO>()
            {
                ErrorMassage = ErrorMessage.InternalServerError,
                ErrorCode = (int) ErrorCode.InternalServerError
            };
        }
    }

    public async Task<BaseResult<ActorDTO>> GetActorByIdAsync(int id)
    {
        try
        {
            var actor = await _repository.GetAll()
                .Select(x => new ActorDTO
                (
                    x.Id,
                    x.Lastname,
                    x.Firstname,
                    x.Secondname,
                    x.PhoneNumber,
                    x.Email,
                    x.City,
                    x.Street,
                    x.House,
                    x.Apartament
                ))
                .FirstOrDefaultAsync(x => x.id == id);
            
            if (actor == null)
            {
                _logger.Warning(ErrorMessage.DataNotFount, id);
                return new BaseResult<ActorDTO>()
                {
                    ErrorMassage = ErrorMessage.DataNotFount,
                    ErrorCode = (int)ErrorCode.DataNotFount
                };
            }

            return new BaseResult<ActorDTO>()
            {
                Data = actor
            };
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            return new BaseResult<ActorDTO>()
            {
                ErrorMassage = ErrorMessage.InternalServerError,
                ErrorCode = (int) ErrorCode.InternalServerError
            };
        }

        
    }
    
    
}