using dataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modeli;
using Modeli.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinestar_WEB_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProjekcijaController:ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public ProjekcijaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        [HttpPost]

        
        public ActionResult Add([FromBody] ProjekcijaAddVm x)
        {
            //if (x.filmId == null)
            //    return BadRequest("Morate unijeti id filma");

            VrstaProjekcije pom = _dbContext.vrstaProjekcije.Find(x.vrstaProjekcijeId);
            Film pomFilm = _dbContext.filmovi.Find(x.filmId);

            if (pom == null || pomFilm == null)
                return BadRequest("Neispravan unos ID-a za film ili vrstu projekcije");
            

            Projekcija nova = new Projekcija()/////POPRAVITI DETALJIFILMA
            {
                dan=x.dan,
                vrijemePrikazivanja=x.vrijemePrikazivanja,
                vrstaProjekcijeId=x.vrstaProjekcijeId,
                vrstaProjekcije=pom,
                filmId=x.filmId,
                film=pomFilm
                
            };

            _dbContext.Add(nova);
            _dbContext.SaveChanges();
            return Ok(nova);
        }
        [HttpGet]
        public List<Projekcija> GetAll(int? _id)
        {
            
            return _dbContext.projekcije.Include(x => x.vrstaProjekcije)
                .Include(x => x.film)
                .Where(x => _id == null || _id == x.id).ToList();
            

        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (_dbContext.projekcije.Count() < 1)
                return BadRequest("Nije pronadjen ni jedan film");

            Projekcija brisi = _dbContext.projekcije.Find(id);

            if (brisi == null)
                return BadRequest("pogresan ID");




            _dbContext.Remove(brisi);

            _dbContext.SaveChanges();
            return Ok(brisi);
        }
        [HttpPost]
        public ActionResult Update(int id, [FromBody] ProjekcijaAddVm x)
        {
            Projekcija edit = _dbContext.projekcije.Find(id);
            VrstaProjekcije editVrsta = _dbContext.vrstaProjekcije.Find(x.vrstaProjekcijeId);
            Film editFilm = _dbContext.filmovi.Find(x.filmId);

            if (editFilm == null)
                return BadRequest("pogresan ID filma");

            if (editVrsta==null)
                return BadRequest("pogresan ID vrste projekcije");


            if (edit == null)
                return BadRequest("pogresan ID");

            edit.dan = x.dan;
            edit.vrijemePrikazivanja = x.vrijemePrikazivanja;
            edit.vrstaProjekcijeId = x.vrstaProjekcijeId;
            edit.vrstaProjekcije = _dbContext.vrstaProjekcije.Find(x.vrstaProjekcijeId);
            edit.filmId = x.filmId;
            edit.film = _dbContext.filmovi.Find(x.filmId);



            _dbContext.SaveChanges();
            return Ok(edit);
        }
    }
}
