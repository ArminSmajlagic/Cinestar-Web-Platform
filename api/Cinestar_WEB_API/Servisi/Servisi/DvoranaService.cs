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
    public class DvoranaService:BaseService<Dvorana,object>
    {
        private readonly IConfiguration config;
        private readonly ILogger logger;
        private readonly ApplicationDbContext db_context;

        public DvoranaService(IConfiguration _config, ILogger _logger, ApplicationDbContext _db_context) : base(_config, _logger, _db_context)
        {
            //this.db = db;
            this.config = _config;
            this.logger = _logger;
            db_context = _db_context;
        }

        public override Dvorana Update(int id, Dvorana obj)
        {
            var set = db_context.dvorana;

            var dvorana = set.Find(id);

            dvorana.brojDvorane = obj.brojDvorane;
            dvorana.brojSjedista = obj.brojSjedista;
            dvorana.kinoId = obj.kinoId;

            db_context.SaveChanges();

            return obj;
        }

        public override Dvorana Insert(Dvorana dvorana)
        {
            dvorana.kino = db_context.kino.Find(dvorana.kinoId);


            db_context.dvorana.Add(dvorana);

            db_context.SaveChanges();

            return dvorana;

        }
    }
}
