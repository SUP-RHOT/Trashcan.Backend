namespace Trashcan.Domain.Enum;

public enum ErrorCode
{
    InternalServerError = 1,
    DataNotFount = 2,
    
    ActorAlreadyExists = 11,
    InvalidPassword = 12,
    
    AddressNotSupported = 21,

    MailError = 70
}