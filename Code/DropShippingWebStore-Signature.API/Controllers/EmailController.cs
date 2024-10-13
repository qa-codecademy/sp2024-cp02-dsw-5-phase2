using DropShippingWebStore_Signature.Services.Implementations;
using DropShippingWebStore_Signature.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DropShippingWebStore_Signature.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async void SendEmail(string subject, string body)
        {
            await _emailService.SendEmailAsync(subject,  body);
        }
        
    }
}
