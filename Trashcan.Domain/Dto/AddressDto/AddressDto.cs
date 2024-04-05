#nullable enable
namespace Trashcan.Domain.Dto.AddressDto;

public record AddressDto
(
    int? Id,
    float? Longitude,
    float? Width,
    string? City,
    string? Street,
    string? House
);