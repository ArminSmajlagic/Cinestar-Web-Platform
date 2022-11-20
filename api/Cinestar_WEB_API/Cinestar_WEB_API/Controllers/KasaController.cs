using Cinestar_WEB_API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Modeli;
using Servisi.IServisi;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cinestar_WBE_API.Controllers
{
    [ApiController]
    [Route("/cinestar_api/seminarski/[controller]")]
    public class KasaController : BaseController<Kasa, object>
    {
        private readonly IBaseService<Kasa,object> kasaService;

        public KasaController(IBaseService<Kasa, object> kasaService):base(kasaService)
        {
            this.kasaService = kasaService;
        }

        
    }
}
