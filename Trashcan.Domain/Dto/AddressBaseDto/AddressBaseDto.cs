#nullable enable
namespace Trashcan.Domain.Dto.AddressBaseDto;

public record AddressBaseDto
(
    int? Id,
    string Longitude,
    string Width,
    string City,
    string Street,
    string House
);