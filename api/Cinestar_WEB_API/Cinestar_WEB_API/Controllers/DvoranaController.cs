using Microsoft.AspNetCore.Mvc;
using Modeli;
using Servisi.IServisi;

namespace Cinestar_WEB_API.Controllers
{

    [ApiController]
    [Route("/cinestar_api/seminarski/[controller]")]
    public class DvoranaController : BaseController<Dvorana, object>
    {
        private readonly IBaseService<Dvorana, object> service;

        public DvoranaController(IBaseService<Dvorana, object> service) : base(service)
        {
            this.service = service;
        }

    }
}
