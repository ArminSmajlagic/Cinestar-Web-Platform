using Microsoft.AspNetCore.Mvc;
using Modeli;
using Servisi.IServisi;

namespace Cinestar_WEB_API.Controllers
{
    [ApiController]
    [Route("/cinestar_api/seminarski/[controller]")]
    public class KartaController : BaseController<Karta, object>
    {
        private readonly IBaseService<Karta, object> service;

        public KartaController(IBaseService<Karta, object> service) :base(service)
        {
            this.service = service;
        }

    }
}
