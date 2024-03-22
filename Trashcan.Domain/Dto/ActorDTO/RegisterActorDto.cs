namespace Trashcan.Domain.Dto.ActorDTO;

public record RegisterActorDto
( 
    string LastName,
    string FirstName,
    string? SecondName,
    string Login,
    string PhoneNumber,
    string Email,
    string City,
    string Street, 
    string House,
    string Apartament
);