using Microsoft.AspNetCore.Mvc;
using Services1.Server.Services;
using Services1.Shared;

namespace Services1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private TestData? _data;
        private IDatabase db = new Database();
        private IEmailService email = new EmailService();

        [HttpGet]
        [Route("testConnection")]
        public ActionResult<TestData> TestConnection()
        {
            return _data = new TestData
            {
                test = "true",
                test2 = true
            };
        }

        [HttpGet]
        [Route("testdatabase/{id:int}")]
        public string TestDatadase(int id)
        {
            return db.Test(id);
        }

        [HttpGet]
        [Route("sendemail")]
        public bool sendemail()
        {
            try
            {
                //email.sendCodeEmail("dawd", "dwad");
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //[HttpGet]
        //[Route("testInterface")]
        //public ActionResult<bool> TestInterface()
        //{
        //    return data.CheckInterface();
        //}

    }
}
