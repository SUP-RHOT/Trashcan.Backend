using Microsoft.AspNetCore.Mvc;
using Trashcan.Domain.Interfaces.Services;
using Trashcan.Domain.Result;

namespace Trashcan.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mail)
        {
            _mailService = mail;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResult<bool>>> SendMailAsync(string email, string subject, string message)
        {
            var responce = await _mailService.SendAsync(email, subject, message);

            if (responce.IsSuccess)
            {
                return Ok(responce);
            }

            return BadRequest(responce);
        }
    }
}
