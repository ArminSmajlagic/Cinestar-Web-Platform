using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Modeli;
using Modeli.ViewModels;
using Servisi.IServisi;

namespace Cinestar_WEB_API.Controllers
{
    [ApiController]
    [Route("/cinestar_api/seminarski/[controller]")]

    public class KorisnikController : BaseController<Korisnik, UpsertKorisnikVM>
    {
        private readonly IBaseService<Korisnik, UpsertKorisnikVM> service;

        public KorisnikController(IBaseService<Korisnik, UpsertKorisnikVM> service) :base(service)
        {

        }


    }
}
