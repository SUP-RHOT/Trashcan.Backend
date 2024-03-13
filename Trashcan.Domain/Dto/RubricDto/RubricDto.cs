#nullable enable
using Trashcan.Domain.Entity;

namespace Trashcan.Domain.Dto.RubricDto;

public record RubricDto
(
    int? Id,
    string Name,
    string Description,
    string Image,
    Institution Institution,
    int InstitutionId
);
