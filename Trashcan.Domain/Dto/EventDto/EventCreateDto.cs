﻿namespace Trashcan.Domain.Dto.EventDto;

public record EventCreateDto
(
    bool Status,
    string TypeMessage,
    string TextMessage,
    string Photo,
    DateTime Date,
    bool Result,
    int ActorId,
    string RubricName,
    string TemplateName
);