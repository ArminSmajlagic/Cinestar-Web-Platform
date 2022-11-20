using dataBase;
using Microsoft.AspNetCore.Mvc;
using Modeli;
using Servisi.IServisi;

namespace Cinestar_WEB_API.Controllers
{
    [ApiController]
    [Route("/cinestar_api/seminarski/[controller]")]
    public class PonudaController : BaseController<Ponuda, object>
    {
        private readonly IBaseService<Ponuda, object> service;

        public PonudaController(IBaseService<Ponuda, object> service) : base(service)
        {

        }
    }
}
