using Microsoft.AspNetCore.Mvc;
using Services1.Server.Services;
using Services1.Shared;

namespace Services1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAboutController : ControllerBase
    {
        private IDatabase db = new Database();

        [HttpGet]
        [Route("getUserAbout/{id:int}")]
        public ActionResult<UserAboutData> GetUserAbout(int id)
        {
            return db.GetUserAbout(id);
        }
    }
}
