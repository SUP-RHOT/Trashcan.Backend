#nullable enable
using Trashcan.Domain.Entity;

namespace Trashcan.Domain.Dto.EventDto;

public record EventDto
(
    int? Id,
    bool Status,
    string TypeMessage,
    string TextMessage,
    string Photo,
    DateTime Date,
    bool Result,
    Actor Actor,
    int ActorId,
    Rubric Rubric,
    int RubricId,
    Address Address,
    int AddressId,
    Template Template,
    int TemplateId
);