using Microsoft.AspNetCore.Mvc;
using NtierArchitecture.Business.Services.Abstract;
using NtierArchitecture.Entities.DTOs.ContactDTOs;

namespace NtierArchitecture.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequestDto request)
        {
            if (request == null)
                return BadRequest("Məlumatlar boş ola bilməz.");

            await _mailService.SendEmailAsync(
                request.ToEmail,
                request.Subject,
                request.Body);

            return Ok("Email Mailtrap inbox-a göndərildi ✅");
        }

    }
}