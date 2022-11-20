using Microsoft.AspNetCore.Mvc;
using Modeli;
using Modeli.ViewModels;
using Servisi.IServisi;
using Servisi.Servisi;

namespace Cinestar_WEB_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisnikVMController : Controller
    {
        private readonly IBaseService<Korisnik, UpsertKorisnikVM> service;
        private readonly IBaseService<Grad, object> gradoviServis;

        public KorisnikVMController(IBaseService<Korisnik, UpsertKorisnikVM> service, IBaseService<Grad, object> gradoviServis)
        {
            this.gradoviServis = gradoviServis;
            this.service = service;

        }
        [HttpGet]
        public ActionResult<KorisnikVM> GetKorisnikViewData()
        {
            return Ok(new KorisnikVM()
            {
                korisnici = service.GetAll().ToList(),
                gradovi = gradoviServis.GetAll().ToList()

            });
        }

        [HttpPost]
        public ActionResult<Korisnik> InsertVM([FromBody] UpsertKorisnikVM obj)
        {
            return Ok(service.InsertVM(obj));
        }

        [HttpPut("{id}")]
        public ActionResult<Korisnik> UpdateVM(int id, [FromBody] UpsertKorisnikVM obj)
        {
            return Ok(service.UpdateVM(id,obj));
        }
    }
}
