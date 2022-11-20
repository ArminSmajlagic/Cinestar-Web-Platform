using dataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Servisi.Servisi;
using System.Threading.Tasks;

namespace Cinestar_WEB_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        private readonly ReportingService reportingService;

        public DashboardController(ReportingService reportingService)
        {
            this.reportingService = reportingService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            reportingService.NotifyClients();

            return Ok(new { message = "Requst completed!" });
        }


    }
}
