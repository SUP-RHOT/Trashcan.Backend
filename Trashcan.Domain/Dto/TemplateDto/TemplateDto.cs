#nullable enable
namespace Trashcan.Domain.Dto.TemplateDto;

public record TemplateDto
(
    int? Id,
    string Name,
    string Text
);