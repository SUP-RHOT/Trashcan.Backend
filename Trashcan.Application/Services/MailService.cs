using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using Trashcan.Application.Resources;
using Trashcan.Domain.Enum;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;
using Trashcan.Domain.Settings;

namespace Trashcan.Application.Services
{
    /// <inheritdoc />
    public class MailService : IMailService
    {
        private readonly MailSettings _settings;

        /// <summary>
        /// Настройка почты-отправителя.
        /// </summary>
        /// <param name="settings"> Параметры почты-отправителя. </param>
        public MailService(IOptions<MailSettings> settings)
        {
            _settings = settings.Value;
        }

        /// <inheritdoc />
        public async Task<BaseResult<bool>> SendAsync(string email, string subject, string message)
        {
            try
            {
                using var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress(_settings.DisplayName, _settings.From));
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart("Plain")
                {
                    Text = message
                };

                using (var client = new SmtpClient())
                {
                    try
                    {
                        await client.ConnectAsync(_settings.Host, _settings.Port, false);
                        await client.AuthenticateAsync(_settings.UserName, _settings.Password);
                        await client.SendAsync(emailMessage);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    finally
                    {
                        await client.DisconnectAsync(true);
                        client.Dispose();
                    }
                }

                return new BaseResult<bool> { Data = true };
            }
            catch (Exception e)
            {
                return new BaseResult<bool>()
                {
                    ErrorMassage = ErrorMessage.MailError,
                    ErrorCode = (int)ErrorCode.MailError
                };
            }
        }
    }
}
