using Microsoft.AspNetCore.Mvc;
using Services1.Server.Services;
using Services1.Shared;

namespace Services1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserContactController : ControllerBase
    {
        private IDatabase db = new Database();

        [HttpGet]
        [Route("getUserContacts/{id:int}")]
        public ActionResult<IEnumerable<UserContactData>> GetUserContacts(int id)
        {
            return db.GetUserContact(id);
        }

        [HttpPost]
        [Route("setUserContact")]
        public ActionResult<bool> SetUserContact(UserContactData user)
        {
            return db.InsertNumber(user);
        }
    }
}
