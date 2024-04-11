namespace Trashcan.Domain.Dto.EventDto;

public record EventDataDTO
(
    bool Status,
    string TypeMessage,
    string TextMessage,
    string Photo,
    DateTime Date,
    bool Result,
    int ActorId,
    int RubricId,
    int AddressId,
    int TemplateId
);