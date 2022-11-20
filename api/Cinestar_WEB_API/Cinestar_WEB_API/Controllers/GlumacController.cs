using dataBase;
using Microsoft.AspNetCore.Mvc;
using Modeli;
using Modeli.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cinestar_WEB_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GlumacController: ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public GlumacController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        [HttpPost]
        public ActionResult Add([FromBody]GlumacAddVm x)
        {
            if (string.IsNullOrEmpty(x._ime) || string.IsNullOrEmpty(x._prezime))
                return BadRequest("Provjerite ime i prezime glumca pa pokušajte ponovo");

            string reg = @"^\d{2}[-][A-Z][a-z]{2}[-]\d{2}";

            if (!Regex.IsMatch(x._datumRodj.ToString(), reg))
                return BadRequest("Neispravan format datuma rodjenja" + x._datumRodj);

            Glumac dodaj = new Glumac()
            {
                ime = x._ime,
                prezime = x._prezime,
                datumRodjenja = x._datumRodj
            };
            _dbContext.Add(dodaj);
            _dbContext.SaveChanges();
            return Ok(dodaj);
        }
        //[HttpPost]
        //public Glumac Add(string _ime,string _prezime,DateTime _datumRodj)
        //{
        //    Glumac dodaj = new Glumac()
        //    {
        //        ime = _ime,
        //        prezime = _prezime,
        //        datumRodjenja = _datumRodj
        //    };
        //    _dbContext.Add(dodaj);
        //    _dbContext.SaveChanges();
        //    return dodaj;
        //}
        [HttpGet] 
        public List<Glumac> GetAll(int? _id)
        {
            return _dbContext.glumci.Where(x=> _id==null ||_id==x.id ).ToList();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (_dbContext.glumci.Count() < 1)
                return BadRequest("Nije pronadjen ni jedan glumac");

            Glumac brisi = _dbContext.glumci.Find(id);

            if (brisi == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(brisi);

            _dbContext.SaveChanges();
            return Ok(brisi);
        }
        [HttpPost]
        public ActionResult Update(int id, [FromBody] GlumacAddVm x)
        {
            Glumac edit = _dbContext.glumci.Find(id);

            if (edit == null)
                return BadRequest("pogresan ID");

            if (string.IsNullOrEmpty(x._ime) || string.IsNullOrEmpty(x._prezime))
                return BadRequest("Provjerite ime i prezime glumca pa pokušajte ponovo");

            string reg = @"^\d{2}[-][A-Z][a-z]{2}[-]\d{2}";

            if (!Regex.IsMatch(x._datumRodj.ToString(), reg))
                return BadRequest("Neispravan format datuma rodjenja " + x._datumRodj);

            edit.ime = x._ime;
            edit.prezime = x._prezime;
            edit.datumRodjenja = x._datumRodj;

            _dbContext.SaveChanges();
            return Ok(edit);
        }
    }
}
