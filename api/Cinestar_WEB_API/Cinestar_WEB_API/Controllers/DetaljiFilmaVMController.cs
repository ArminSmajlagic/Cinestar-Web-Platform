using dataBase;
using Microsoft.AspNetCore.Mvc;
using Modeli;
using Servisi.IServisi;

namespace Cinestar_WEB_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetaljiFilmaVMController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public DetaljiFilmaVMController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;

        }
        [HttpGet("{id}")]
        public ActionResult<DeskripcijaFilmaVM> GetDetaljiFilmaVM( int id)
        {
            var film = _dbContext.filmovi.Find(id);

            var detalji = _dbContext.detaljiFilma.Find(film.detaljiFilmaID);

            return Ok(new DeskripcijaFilmaVM()
            {
                detalji = detalji,
                film = film
            });
        }
    }
}
