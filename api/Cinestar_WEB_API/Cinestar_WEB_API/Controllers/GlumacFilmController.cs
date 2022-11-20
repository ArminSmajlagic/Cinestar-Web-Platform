using dataBase;
using Microsoft.AspNetCore.Mvc;
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
    public class GlumacFilmController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public GlumacFilmController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        [HttpPost]
        public ActionResult Add([FromBody] GlumacFilmAddVm x)
        {
            //if (x.glumacId == null || x.filmId == null)
            //    return BadRequest("Provjerite unos ID-jeva");


            Glumac gCheck = _dbContext.glumci.Find(x.glumacId);
            if (gCheck == null)
                return BadRequest("Ne postoji glumac sa tim ID-jem u bazi podataka");

            Film fCheck = _dbContext.filmovi.Find(x.filmId);
            if (fCheck == null)
                return BadRequest("Ne postoji film sa tim ID-jem u bazi podataka");

            List<GlumacFilm> check = _dbContext.glumacFilm.Where(y => y.filmId == x.filmId &&
              y.glumacId == x.glumacId).ToList();
            if (check.Count > 0)
                return BadRequest("Taj glumac je vec dodan na film");


            GlumacFilm dodaj = new GlumacFilm()
            {
                glumacId = x.glumacId,
                filmId = x.filmId,
                glumac = gCheck,
                film = fCheck
            };
            _dbContext.Add(dodaj);
            _dbContext.SaveChanges();
            return Ok(dodaj);
        }
        [HttpGet]
        public List<Glumac> GetGlumciZaFilm(int filmId)
        {
            List<Glumac> glumci = new List<Glumac>();
            Glumac dodaj = new Glumac();

            List<Glumac> temp = _dbContext.glumci.ToList();

            foreach (var glumacFilm in _dbContext.glumacFilm)
            {
                if (glumacFilm.filmId == filmId)
                {
                    dodaj =temp.Where(x=>x.id==glumacFilm.glumacId).ToList()[0];
                    glumci.Add(dodaj);
                    dodaj = null;
                }
                    
            }
            return glumci;
        }
        [HttpGet]
        public List<GlumacFilm> GetAll(int? _id)
        {
            return _dbContext.glumacFilm.Where(x => _id == null || _id == x.id).ToList();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (_dbContext.glumacFilm.Count() < 1)
                return BadRequest("Nije pronadjen ni jedan zapis glumca u filmu");

            GlumacFilm brisi = _dbContext.glumacFilm.Find(id);

            if (brisi == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(brisi);

            _dbContext.SaveChanges();
            return Ok(brisi);
        }
        [HttpPost]
        public ActionResult DeleteGlumciZaFilm(int filmId,int glumacId)
        {
            if (_dbContext.glumacFilm.Count() < 1)
                return BadRequest("Nije pronadjen ni jedan zapis glumca u filmu");



            GlumacFilm brisi = _dbContext.glumacFilm.Where(x=>x.glumacId==glumacId &&
            x.filmId==filmId).ToList()[0];

            //if (brisi == null)
            //    return BadRequest("pogresan ID");

            _dbContext.Remove(brisi);

            _dbContext.SaveChanges();
            return Ok(brisi);
        }
        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] GlumacFilmAddVm x)
        {
            GlumacFilm edit = _dbContext.glumacFilm.Find(id);

            if (edit == null)
                return BadRequest("pogresan ID");

            Glumac gCheck = _dbContext.glumci.Find(x.glumacId);
            if (gCheck == null)
                return BadRequest("Ne postoji glumac sa tim ID-jem u bazi podataka");

            Film fCheck = _dbContext.filmovi.Find(x.filmId);
            if (fCheck == null)
                return BadRequest("Ne postoji film sa tim ID-jem u bazi podataka");

            List<GlumacFilm> check = _dbContext.glumacFilm.Where(y => y.filmId == x.filmId &&
              y.glumacId == x.glumacId).ToList();
            if (check.Count > 0)
                return BadRequest("Taj glumac je vec dodan na film");


            edit.glumacId = x.glumacId;
            edit.filmId = x.filmId;
           

            _dbContext.SaveChanges();
            return Ok(edit);
        }
    }
}
