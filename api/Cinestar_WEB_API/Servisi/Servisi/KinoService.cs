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
    public class KinoService:BaseService<Kino,object>
    {
        private readonly IConfiguration config;
        private readonly ILogger logger;
        private readonly ApplicationDbContext db_context;
        public KinoService(IConfiguration _config, ILogger _logger, ApplicationDbContext _db_context):base(_config,_logger,_db_context)
        {
            this.config = _config;
            this.logger = _logger;
            db_context = _db_context;
        }

        public override Kino Update(int id, Kino obj)
        {
            var setKina = db_context.kino;

            var kino = setKina.Find(id);

            if (kino != null)
            {
                var setGradova = db_context.grad;
                kino.naziv = obj.naziv;
                kino.gradId = obj.gradId;

                var grad = setGradova.Find(obj.gradId);

                obj.grad = grad;

                db_context.SaveChanges();

                return obj;
            }

            return null;
        }

        public override Kino Insert(Kino obj)
        {
            var setKina = db_context.kino;
            var setGradova = db_context.grad;

            var grad = setGradova.Find(obj.gradId);

            obj.grad=grad;

            setKina.Add(obj);

            db_context.SaveChanges();

            return obj;
        }
    }
}
