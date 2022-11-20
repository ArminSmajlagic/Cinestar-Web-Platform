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
    public class VrstaProjekcijeController:ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public VrstaProjekcijeController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        [HttpPost]
        public VrstaProjekcije Add([FromBody] VrstaProjekcijeAddVm x)
        {
            if (string.IsNullOrEmpty(x.dimenzija))
                x.dimenzija = "Nepoznata dimenzija";

            VrstaProjekcije nova = new VrstaProjekcije()
            {
                dimenzija = x.dimenzija
            };

            _dbContext.Add(nova);
            _dbContext.SaveChanges();
            return nova;
        }

        [HttpGet]
        public List<VrstaProjekcije> GetAll(int? _id)
        {
            return _dbContext.vrstaProjekcije.Where(x => _id == null || _id == x.id).ToList();

        }
        [HttpGet]
        public List<StavkaPonude> GetStavke(int _id)
        {
            return _dbContext.stavkaPonude.Where(x => x.ponudaId==_id).ToList();

        }

        [HttpGet]
        public List<Proizvod> GetProizvodi(int _id)
        {
            return _dbContext.proizvod.Where(x => x.ponudaId == _id).ToList();

        }

        [HttpPost]
        public ActionResult Update(int id, [FromBody] VrstaProjekcijeAddVm x)
        {
            VrstaProjekcije edit = _dbContext.vrstaProjekcije.Find(id);

            if (edit == null)
                return BadRequest("pogresan ID");

            edit.dimenzija = x.dimenzija;


            _dbContext.SaveChanges();
            return Ok(edit);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (_dbContext.vrstaProjekcije.Count() < 1)
                return BadRequest("Nije pronadjena ni jedna vrsta projekcije");

            VrstaProjekcije brisi = _dbContext.vrstaProjekcije.Find(id);

            if (brisi == null)
                return BadRequest("pogresan ID");


            _dbContext.Remove(brisi);

            _dbContext.SaveChanges();
            return Ok(brisi);
        }
    }
}
