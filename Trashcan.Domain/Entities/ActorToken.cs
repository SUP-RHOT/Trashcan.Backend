using Trashcan.Domain.Entities.BaseEntity;

namespace Trashcan.Domain.Entity;

public class ActorToken : IBaseEntity<int>
{
    public int Id { get; set; }
    
    public string RefreshToken { get; set; }

    public DateTime RefreshTokenExpiryTime { get; set; }

    public Actor Actor { get; set; }

    public int ActorId { get; set; }
}