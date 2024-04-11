using Trashcan.Domain.Entity;

namespace Trashcan.Domain.Dto.EventDto;

public record EventInfoDto
(
    int Id,
    bool Status,
    string TypeMessage,
    string TextMessage,
    string Photo,
    DateTime Date,
    bool Result,
    Address Address
);