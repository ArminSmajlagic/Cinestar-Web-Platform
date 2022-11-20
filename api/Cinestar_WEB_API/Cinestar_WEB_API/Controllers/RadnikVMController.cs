using Microsoft.AspNetCore.Mvc;
using Modeli;
using Modeli.ViewModels;
using Servisi.IServisi;

namespace Cinestar_WEB_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RadnikVMController : Controller
    {
        private readonly IBaseService<Radnik, UpsertRadnikVM> service;
        private readonly IBaseService<Grad, object> gradoviServis;

        public RadnikVMController(IBaseService<Radnik, UpsertRadnikVM> service, IBaseService<Grad,object> gradoviServis)
        {
            this.gradoviServis = gradoviServis;
            this.service = service;

        }
        [HttpGet]
        public ActionResult<RadnikVM> GetRadnikViewData()
        {
            return Ok(new RadnikVM()
            {
                radnici = service.GetAll().ToList(),
                gradovi = gradoviServis.GetAll().ToList()

            });
        }

        [HttpPost]
        public ActionResult<Radnik> InsertVM([FromBody] UpsertRadnikVM obj)
        {
            return Ok(service.InsertVM(obj));
        }

        [HttpPut("{id}")]
        public ActionResult<Radnik> UpdateVM(int id, [FromBody] UpsertRadnikVM obj)
        {
            return Ok(service.UpdateVM(id, obj));
        }
    }
}
