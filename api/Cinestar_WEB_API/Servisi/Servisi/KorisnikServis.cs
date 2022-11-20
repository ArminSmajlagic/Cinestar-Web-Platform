using dataBase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Modeli;
using Modeli.ViewModels;


namespace Servisi.Servisi
{
    public class KorisnikServis:BaseService<Korisnik,UpsertKorisnikVM>
    {
        private readonly IConfiguration config;
        private readonly ILogger logger;
        private readonly ApplicationDbContext db_context;
        private readonly ReportingService reportingService;

        public KorisnikServis(IConfiguration _config, ILogger _logger, ApplicationDbContext _db_context, ReportingService reportingService) :base(_config, _logger, _db_context)
        {
            //this.db = db;
            this.config = _config;
            this.logger = _logger;
            db_context = _db_context;
            this.reportingService = reportingService;

        }

        public override Korisnik Update(int id, Korisnik obj)
        {
            var set = db_context.Set<Korisnik>();
            if (set != null)
            {
                var user = set.Find(id);
                if (user != null)
                {
                    user.ime_prezime = obj.ime_prezime;
                    user.username = obj.username;
                    user.email = obj.email;
                    user.password = obj.password;
                    user.confirmed = obj.confirmed;
                    user.broj_telefona = obj.broj_telefona;
                    user.b_date = obj.b_date;
                    user.datum_kreiranja_racuna = obj.datum_kreiranja_racuna;
                    user.gradId = obj.gradId;

                    db_context.SaveChanges();

                    return user;
                }
                else return null;

            }

            return null;
        }

        public override Korisnik UpdateVM(int id, UpsertKorisnikVM obj)
        {
            var set = db_context.Set<Korisnik>();
            if (set != null)
            {
                var user = set.Find(id);
                if (user != null)
                {
                    if (user.ime_prezime != obj.ime_prezime && obj.ime_prezime != "")
                        user.ime_prezime = obj.ime_prezime;

                    if (user.username != obj.username && obj.username != "")
                        user.username = obj.username;

                    if (user.email != obj.email && obj.email != "")
                        user.email = obj.email;

                    if (user.password != obj.password && obj.password != "")
                        user.password = obj.password;

                    if (user.broj_telefona != obj.broj_telefona && obj.broj_telefona != -1)
                        user.broj_telefona = obj.broj_telefona;

                    if (user.b_date != obj.b_date)
                        user.b_date = obj.b_date;

                    if(user.confirmed!=obj.confirmed&&obj.confirmed!=-1)
                        user.confirmed = obj.confirmed;

                    db_context.SaveChanges();

                    return user;
                }
                else return user;

            }

            return null;
        }

        public override Korisnik InsertVM(UpsertKorisnikVM obj)
        {

            var mail = new ConfirmMailKorisnik() { issuedConfCode = "123456" };

            var resp = db_context.confirmMailKorisnik.Add(mail);

            db_context.SaveChanges();

            Korisnik newUser = new Korisnik();

            newUser.email = obj.email;
            newUser.confMailXkorisnici = mail;
            newUser.confMailXkorisniciId = resp.Entity.id;
            newUser.grad = db_context.grad.Find(obj.gradId);
            newUser.gradId = obj.gradId;
            newUser.b_date = obj.b_date;
            newUser.broj_telefona = obj.broj_telefona;
            newUser.confirmed = obj.confirmed;
            newUser.datum_kreiranja_racuna = System.DateTime.Now;
            newUser.ime_prezime = obj.ime_prezime;
            newUser.password = obj.password;
            newUser.spol = obj.spol;
            newUser.username = obj.username;


            db_context.korisnici.Add(newUser);

            db_context.SaveChanges();

            reportingService.NotifyClients();
            
            return newUser;
        }
    }
}
