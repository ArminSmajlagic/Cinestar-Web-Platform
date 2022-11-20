using Microsoft.AspNetCore.Mvc;
using Modeli;
using Servisi.IServisi;

namespace Cinestar_WEB_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SnacksVMController : Controller
    {
        private readonly IBaseService<Proizvod, object> service;

        public SnacksVMController(IBaseService<Proizvod, object> service)
        {
            this.service = service;

        }
        [HttpGet]
        public ActionResult<SnacksVM> GetSnacksVM()
        {
            return Ok(new SnacksVM()
            {
                proizvodi = service.GetAll().ToList()

            });
        }
    }
}
