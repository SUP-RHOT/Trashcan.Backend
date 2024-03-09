#nullable enable
namespace Trashcan.Domain.Dto.ActorDTO;

public record ActorDto
( 
    int? Id,
    string LastName,
    string FirstName,
    string? SecondName,
    string PhoneNumber,
    string Email,
    string City,
    string Street, 
    string House,
    string Apartament
);