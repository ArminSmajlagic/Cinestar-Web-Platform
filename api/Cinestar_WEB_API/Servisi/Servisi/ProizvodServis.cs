using dataBase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servisi.Servisi
{
    public class ProizvodServis : BaseService<Proizvod, object>
    {
        private readonly IConfiguration config;
        private readonly ILogger logger;
        private readonly ApplicationDbContext db_context;

        public ProizvodServis(IConfiguration _config, ILogger _logger, ApplicationDbContext _db_context) : base(_config, _logger, _db_context)
        {
            //this.db = db;
            config = _config;
            logger = _logger;
            db_context = _db_context;
        }

        public override Proizvod Insert(Proizvod obj)
        {
            var Ponuda = db_context.ponuda.Find(obj.ponudaId);

            if (Ponuda == null)
                return new Proizvod() { naziv = "error |  ponuda nije nađena" };

            obj.ponude = Ponuda;

            db_context.proizvod.Add(obj);

            db_context.SaveChanges();

            return obj;
        }

        public override Proizvod Update(int id, Proizvod obj)
        {
            var set = db_context.Set<Proizvod>();

            var proizvod = set.Find(id);

            if(proizvod != null)
            {
                proizvod.ponudaId = obj.ponudaId;

                var Ponuda = db_context.ponuda.Find(obj.ponudaId);

                if (Ponuda == null)
                    return new Proizvod() { naziv = "error |  ponuda nije nađena" };

                obj.ponude = Ponuda;

                proizvod.naziv = obj.naziv;

                proizvod.porcija = obj.porcija;

                proizvod.cijena = obj.cijena;

                db_context.SaveChanges();

                return obj;
            }

            return null;
        }
    }
}
