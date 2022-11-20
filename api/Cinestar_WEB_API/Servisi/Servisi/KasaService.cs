using dataBase;
using Microsoft.EntityFrameworkCore;
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
    public class KasaService : BaseService<Kasa,object>
    {
        private readonly IConfiguration config;
        private readonly ILogger logger;
        private readonly ApplicationDbContext db_context;
        public KasaService(ApplicationDbContext _db_context, ILogger _logger, IConfiguration _config) :base(_config,_logger, _db_context)
        {
            this.config = _config;
            this.logger = _logger;
            db_context = _db_context;
        }

        public override Kasa Insert(Kasa item)
        {
            item.kino = db_context.kino.Find(item.kinoId);

            if (item.kino != null)
            {
                db_context.kasa.Add(item);
                db_context.SaveChanges();
            }
            else
            {
                item.id = -1;
            }

            return item;
        }

        public override Kasa Update(int id, Kasa item)
        {
            var kasa = db_context.kasa.Find(id);
            if (kasa == null)
                return null;
            kasa.stanje_kase = item.stanje_kase;
            kasa.aktivna=item.aktivna;

            db_context.SaveChanges();

            return item;
        }
    }
}
