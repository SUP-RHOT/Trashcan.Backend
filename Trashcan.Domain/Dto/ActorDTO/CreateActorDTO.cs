namespace Trashcan.Domain.Dto.ActorDTO;

public record CreateActorDTO
(
    char lastName,
    char firstName,
    char secondName,
    char phoneNumber,
    char email,
    char city,
    char street, 
    char house,
    char apartament
);