using Microsoft.AspNetCore.Mvc;
using Modeli;
using Servisi.IServisi;

namespace Cinestar_WEB_API.Controllers
{
    [ApiController]
    [Route("/cinestar_api/seminarski/[controller]")]
    public class GradController : BaseController<Grad, object>
    {
        private readonly IBaseService<Grad, object> service;

        public GradController(IBaseService<Grad, object> service) : base(service)
        {

        }
    }
}
