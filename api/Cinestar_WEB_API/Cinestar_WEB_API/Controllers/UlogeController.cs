using Microsoft.AspNetCore.Mvc;
using Modeli;
using Servisi.IServisi;

namespace Cinestar_WEB_API.Controllers
{
    [ApiController]
    [Route("/cinestar_api/seminarski/[controller]")]
    public class UlogeController : BaseController<VrstaRadnika, object>
    {
        private readonly IBaseService<VrstaRadnika, object> service;

        public UlogeController(IBaseService<VrstaRadnika, object> service) : base(service)
        {

        }
    }
}
