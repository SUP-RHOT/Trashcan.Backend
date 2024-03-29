using Trashcan.Domain.Result;

namespace Trashcan.Domain.Interfaces.Services
{
    /// <summary>
    /// Для отправки сообщений по почте.
    /// </summary>
    public interface IMailService
    {
        /// <summary>
        /// Отправить сообщение.
        /// </summary>
        /// <param name="email"> Адрес получателя. </param>
        /// <param name="subject"> Тема сообщения. </param>
        /// <param name="message"> Тело сообщения. </param>
        /// <returns> Результат отправки. </returns>
        Task<BaseResult<bool>> SendAsync(string email, string subject, string message);
    }
}