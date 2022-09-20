using Microsoft.AspNetCore.Mvc;
using Services1.Server.Services;
using Services1.Shared;

namespace Services1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IDatabase db = new Database();

        [HttpGet]
        [Route("getReportById/{id:int}")]
        public ActionResult<Reports> GetReportById(int id)
        {
            return db.GetReports_byId(id);
        }

        [HttpGet]
        [Route("getReportByMark/{id:int}/{value:int}")]
        public ActionResult<IEnumerable<Reports>> GetReportByMark(int id, int value)
        {
            return db.GetReports_byMark(id, value);
        }

        [HttpPost]
        [Route("setReport")]
        public ActionResult<bool> SetReport(Reports rep)
        {
            return db.InsertReport(rep);
        }

        [HttpGet]
        [Route("updateReport/{id:int}/{value:int}")]
        public ActionResult<bool> UpdateReport(int id, int value)
        {
            return db.UpdateReports(id, value);
        }
    }
}
