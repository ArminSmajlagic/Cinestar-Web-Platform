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
    public class SjedisteService : BaseService<Sjediste, object>
    {
        private readonly IConfiguration config;
        private readonly ILogger logger;
        private readonly ApplicationDbContext db_context;

        public SjedisteService(IConfiguration _config, ILogger _logger, ApplicationDbContext _db_context) : base(_config, _logger, _db_context)
        {
            //this.db = db;
            this.config = _config;
            this.logger = _logger;
            db_context = _db_context;
        }

        public override Sjediste Update(int id, Sjediste obj)
        {
            var set = db_context.sjediste;

            var sjediste = set.Find(id);

            sjediste.kolona = obj.kolona;
            sjediste.dvoranaId = obj.dvoranaId;
            sjediste.red = obj.red;

            db_context.SaveChanges();

            return obj;
        }

        public override Sjediste Insert(Sjediste item)
        {
            item.dvorana=db_context.dvorana.Find(item.dvoranaId);

            db_context.sjediste.Add(item);

            db_context.SaveChanges();

            return item;
        }
    }
}
