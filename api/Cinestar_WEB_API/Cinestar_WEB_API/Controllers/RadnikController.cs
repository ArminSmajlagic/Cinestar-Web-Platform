using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Modeli;
using Modeli.ViewModels;
using Servisi.IServisi;

namespace Cinestar_WEB_API.Controllers
{
    [ApiController]
    [Route("/cinestar_api/seminarski/[controller]")]

    public class RadnikController : BaseController<Radnik, UpsertRadnikVM>
    {
        private readonly IBaseService<Radnik, UpsertRadnikVM> service;

        public RadnikController(IBaseService<Radnik, UpsertRadnikVM> service) : base(service)
        {

        }


    }
}
