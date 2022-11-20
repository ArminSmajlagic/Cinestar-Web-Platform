using Microsoft.AspNetCore.Mvc;
using Modeli;
using Servisi.IServisi;

namespace Cinestar_WEB_API.Controllers
{
    [ApiController]
    [Route("/cinestar_api/seminarski/[controller]")]
    public class ProizvodController : BaseController<Proizvod, object>
    {
        private readonly IBaseService<Proizvod, object> service;

        public ProizvodController(IBaseService<Proizvod, object> service) : base(service)
        {

        }
    }
}
