using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services1.Shared;
using Services1.Server.Services;

namespace Services1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private IEmailService service = new EmailService();

        [HttpPost]
        [Route("sendEmailWithMessage")]
        public ActionResult SendEmailWithMessage(EmailMessage email)
        {
            try
            {
                service.SendEmail(email);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }            
        }
    }
}
