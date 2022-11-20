using dataBase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Modeli;
using Servisi.IServisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servisi.Servisi
{
    public class PonudaServis : BaseService<Ponuda, object>
    {
        private readonly IConfiguration config;
        private readonly ILogger logger;
        private readonly ApplicationDbContext db_context;

        public PonudaServis(IConfiguration _config, ILogger _logger, ApplicationDbContext _db_context) : base(_config, _logger, _db_context)
        {
            //this.db = db;
            this.config = _config;
            this.logger = _logger;
            db_context = _db_context;
        }
       
        public override Ponuda Insert(Ponuda obj)
        {
            obj.radnik = db_context.radnici.Find(obj.radnikId);

            obj.radnik.grad= db_context.grad.Find(obj.radnik.gradId);    

            obj.radnik.vrstaRadnika= db_context.vrstaRadnika.Find(obj.radnik.vrstaRadnikaId);    

            db_context.ponuda.Add(obj);

            db_context.SaveChanges();

            return obj;
        }

        public override Ponuda Update(int id, Ponuda obj)
        {
            var ponuda = db_context.ponuda.Find(id);
            if(ponuda != null)
            {
                ponuda.vrsta_ponude = obj.vrsta_ponude;
                ponuda.krajPonude = obj.krajPonude;
                ponuda.pocetakPonude = obj.pocetakPonude;
                ponuda.trajanjePonude = obj.trajanjePonude;
                if (obj.radnikId != 0)
                {
                    ponuda.radnikId = obj.radnikId;
                    var radnik = db_context.radnici.Find(obj.radnikId);
                    //radnik.grad = db_context.grad.Find(obj.radnik.gradId);
                    radnik.grad = db_context.grad.Find(radnik.gradId);

                    //radnik.vrstaRadnika = db_context.vrstaRadnika.Find(obj.radnik.vrstaRadnikaId);
                    radnik.vrstaRadnika = db_context.vrstaRadnika.Find(radnik.vrstaRadnikaId);

                    ponuda.radnik = radnik;

                }

                db_context.SaveChanges();
                return obj;
            }

            return null;
        }
    }
}
