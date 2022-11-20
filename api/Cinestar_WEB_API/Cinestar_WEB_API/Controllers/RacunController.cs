using Microsoft.AspNetCore.Mvc;
using Modeli;
using Servisi.IServisi;

namespace Cinestar_WEB_API.Controllers
{
    [ApiController]
    [Route("/cinestar_api/seminarski/[controller]")]

    public class RacunaController : BaseController<Racun, object>
    {
        private readonly IBaseService<Racun, object> service;

        public RacunaController(IBaseService<Racun, object> service) : base(service)
        {
            this.service = service;
        }

    }
}
