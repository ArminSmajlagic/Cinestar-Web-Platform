using dataBase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Modeli;
using Modeli.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servisi.Servisi
{
    public class RadnikService : BaseService<Radnik, UpsertRadnikVM>
    {
        private readonly IConfiguration config;
        private readonly ILogger logger;
        private readonly ApplicationDbContext db_context;

        public RadnikService(IConfiguration _config, ILogger _logger, ApplicationDbContext _db_context) : base(_config, _logger, _db_context)
        {
            //this.db = db;
            this.config = _config;
            this.logger = _logger;
            db_context = _db_context;
        }

        public override Radnik Update(int id, Radnik _user)
        {
            var radnik = db_context.radnici.Find(id);

            if (radnik != null)
            {
                radnik.ime_prezime = _user.ime_prezime;
                radnik.username = _user.username;
                radnik.email = _user.email;
                radnik.password = _user.password;
                radnik.broj_telefona = _user.broj_telefona;
                radnik.b_date = _user.b_date;
                radnik.strucnaSprema = _user.strucnaSprema;
                radnik.datum_uposljenja = _user.datum_uposljenja;
                radnik.spol = _user.spol;
                radnik.plata = _user.plata;
                radnik.jmbg = _user.jmbg;
                if (_user.vrstaRadnikaId != 0)
                {
                    radnik.vrstaRadnikaId = _user.vrstaRadnikaId;
                    radnik.vrstaRadnika = db_context.vrstaRadnika.FirstOrDefault(x => x.id == radnik.vrstaRadnikaId);
                }

                radnik.gradId = _user.gradId;
                radnik.grad = db_context.grad.Find(_user.gradId);

                db_context.SaveChanges();

                return radnik;
            }

            return null;

        }

        public override Radnik UpdateVM(int id, UpsertRadnikVM _user)
        {
            var radnik = db_context.radnici.Find(id);

            if (radnik != null)
            {
                if(radnik.ime_prezime != _user.ime_prezime && _user.ime_prezime != "")
                     radnik.ime_prezime = _user.ime_prezime;

                if (radnik.username != _user.username && _user.username != "")
                    radnik.username = _user.username;

                if (radnik.email != _user.email && _user.email != "")
                    radnik.email = _user.email;

                if (radnik.password != _user.password && _user.password != "")
                    radnik.password = _user.password;

                if (radnik.broj_telefona != _user.broj_telefona && _user.broj_telefona != -1)
                    radnik.broj_telefona = _user.broj_telefona;

                if (radnik.b_date != _user.b_date)
                    radnik.b_date = _user.b_date;

                if (radnik.strucnaSprema != _user.strucnaSprema && _user.strucnaSprema != "")
                    radnik.strucnaSprema = _user.strucnaSprema;

                if (radnik.datum_uposljenja != _user.datum_uposljenja && _user.datum_uposljenja != "")
                    radnik.datum_uposljenja = _user.datum_uposljenja;

                if (radnik.spol != _user.spol && _user.spol != -1)
                    radnik.spol = _user.spol;

                if (radnik.plata != _user.plata && _user.plata != -1)
                    radnik.plata = _user.plata;

                if (radnik.jmbg != _user.jmbg && _user.jmbg != "")
                    radnik.jmbg = _user.jmbg;

                if (radnik.vrstaRadnikaId != _user.vrstaRadnikaId && _user.vrstaRadnikaId != -1)
                {
                    radnik.vrstaRadnikaId = _user.vrstaRadnikaId;
                    radnik.vrstaRadnika = db_context.vrstaRadnika.FirstOrDefault(x => x.id == radnik.vrstaRadnikaId);
                }

                if(radnik.gradId!=_user.gradId && _user.gradId != -1)
                {
                    radnik.gradId = _user.gradId;
                    radnik.grad = db_context.grad.Find(_user.gradId);
                }

                db_context.SaveChanges();

            }

            return radnik;

        }

        public override Radnik Insert(Radnik user)
        {
            user.vrstaRadnika = db_context.vrstaRadnika.Find(user.vrstaRadnikaId);

            user.grad = db_context.grad.Find(user.gradId);

            db_context.radnici.Add(user);

            db_context.SaveChanges();

            return user;

        }

        public override Radnik InsertVM(UpsertRadnikVM obj)
        {

            var mail = new ConfirmMailKorisnik() { issuedConfCode = "123456" };


            db_context.SaveChanges();

            Radnik newUser = null;

            if(obj.gradId != 0 || obj.vrstaRadnikaId!= 0)
            {
                newUser = new Radnik();
                newUser.ime_prezime = obj.ime_prezime;
                newUser.username = obj.username;
                newUser.email = obj.email;
                newUser.b_date = obj.b_date;
                newUser.password = obj.password;
                newUser.broj_telefona = obj.broj_telefona;
                newUser.gradId = obj.gradId;
                newUser.spol = obj.spol;
                newUser.jmbg = obj.jmbg;
                newUser.datum_uposljenja = obj.datum_uposljenja;
                newUser.strucnaSprema = obj.strucnaSprema;
                newUser.plata = obj.plata;
                newUser.vrstaRadnikaId = obj.vrstaRadnikaId;
            
            
                newUser.grad = db_context.grad.Find(obj.gradId);
                newUser.vrstaRadnika = db_context.vrstaRadnika.Find(obj.vrstaRadnikaId);
                db_context.confirmMailKorisnik.Add(mail);    

                db_context.radnici.Add(newUser);

                db_context.SaveChanges();

            }


            return newUser;
        }
    }
}
