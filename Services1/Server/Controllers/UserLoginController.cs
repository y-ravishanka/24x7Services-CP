using Microsoft.AspNetCore.Mvc;
using Services1.Server.Services;
using Services1.Shared;

namespace Services1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private IDatabase db = new Database();

        [HttpGet]
        [Route("getLoginDetails/{email}")]
        public ActionResult<UsersData> GetLoginData(string email)
        {
            return db.GetLogin(email);
        }

        [HttpGet]
        [Route("checkUser/{email}")]
        public ActionResult<bool> CheckUser(string email)
        {
            return db.CheckUser(email);
        }
    }
}
