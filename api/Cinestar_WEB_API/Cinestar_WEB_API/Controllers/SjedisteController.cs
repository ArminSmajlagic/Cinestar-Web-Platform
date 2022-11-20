using Microsoft.AspNetCore.Mvc;
using Modeli;
using Servisi.IServisi;

namespace Cinestar_WEB_API.Controllers
{
    [ApiController]
    [Route("/cinestar_api/seminarski/[controller]")]
    public class SjedisteController : BaseController<Sjediste, object>
    {
        private readonly IBaseService<Sjediste, object> service;

        public SjedisteController(IBaseService<Sjediste, object> service) : base(service)
        {
            this.service = service;
        }

    }
}
