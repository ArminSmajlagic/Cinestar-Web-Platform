using Microsoft.AspNetCore.Mvc;
using Modeli;
using Servisi.IServisi;
using Servisi.Servisi;

namespace Cinestar_WEB_API.Controllers
{
    [ApiController]
    [Route("/cinestar_api/seminarski/[controller]")]
    public class KinoController : BaseController<Kino,object>
    {
        private readonly IBaseService<Kino,object> servis;
        public KinoController(IBaseService<Kino, object> servis) :base(servis)
        {

        }
    }
}
