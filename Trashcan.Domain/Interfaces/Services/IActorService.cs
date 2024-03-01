using Trashcan.Domain.Dto.ActorDTO;
using Trashcan.Domain.Result;

namespace Trashcan.Domain.Interfaces.Services;

public interface IActorService
{
    Task<CollectionResult<ActorDTO>> GetActor();

    Task<BaseResult<ActorDTO>> GetActorByIdAsync(int id);
}