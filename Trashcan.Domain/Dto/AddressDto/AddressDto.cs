#nullable enable
namespace Trashcan.Domain.Dto.AddressDto;

public record AddressDto
(
    int? Id,
    string Longitude,
    string Width,
    string City,
    string Street,
    string House
);