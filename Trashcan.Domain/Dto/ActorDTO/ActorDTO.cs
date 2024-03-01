namespace Trashcan.Domain.Dto.ActorDTO;

public record ActorDTO
(
    int id, 
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