using dataBase;
using Microsoft.AspNetCore.Mvc;
using Modeli;
using Servisi.IServisi;

namespace Cinestar_WEB_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientHomeVMController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ClientHomeVMController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;

        }
        [HttpGet]
        public ActionResult<ClientHomeVM> GetHomeVM()
        {
            var filmovi = _dbContext.filmovi.ToList();

            return Ok(new ClientHomeVM()
            {
                filmovi = filmovi
            });
        }
    }
}
