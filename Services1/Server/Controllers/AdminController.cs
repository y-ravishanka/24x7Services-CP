using Microsoft.AspNetCore.Mvc;
using Services1.Server.Services;
using Services1.Shared;

namespace Services1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IDatabase db = new Database();

        [HttpGet]
        [Route("getAdminLogin/{email}")]
        public ActionResult<UsersData> GetAdminLogin(string email)
        {
            return db.GetAdminLogin(email);
        }

        [HttpGet]
        [Route("checkAdmin/{email}")]
        public ActionResult<bool> CheckAdmin(string email)
        {
            return db.CheckAdmin(email);
        }

        [HttpGet]
        [Route("activeAdmins/{id:int}")]
        public ActionResult<bool> ActiveAdmins(int id)
        {
            return db.ActiveAdmin(id);
        }

        [HttpGet]
        [Route("getInactiveAdmins")]
        public ActionResult<List<UsersData>> GetInactiveAdmins()
        {
            return db.GetInactiveAdmins();
        }

        [HttpPost]
        [Route("setAdmin")]
        public ActionResult<bool> SetAdmin(UsersData users)
        {
            return db.InsertAdminLogin(users);
        }

        [HttpPost]
        [Route("setAdminData")]
        public ActionResult<bool> SetAdminData(AdminData admin)
        {
            return db.InsertAdmin(admin);
        }

        [HttpGet]
        [Route("getAdminData/{id:int}")]
        public ActionResult<AdminData> GetAdminData(int id)
        {
            return db.GetAdminData(id);
        }
    }
}
