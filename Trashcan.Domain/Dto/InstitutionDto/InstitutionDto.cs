#nullable enable
namespace Trashcan.Domain.Dto.InstitutionDto;

public record InstitutionDto
(
    int? Id,
    string Name,
    string City,
    string District,
    string Description
);