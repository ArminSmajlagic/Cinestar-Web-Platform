using dataBase;
using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Modeli;
using Modeli.AuthModeli;
using Modeli.MailModels;
using Modeli.ViewModels;
using Servisi.IServisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Servisi.Servisi
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration config;
        private readonly ILogger logger;
        private readonly ApplicationDbContext db_context;
        private readonly IEmailService emailService;
        private readonly IBaseService<Korisnik,UpsertKorisnikVM> userService;
        private readonly ReportingService reportingService;

        private DiscoveryDocumentResponse _discDocument { get; set; }

        //public CrudRepo(DB_Context db,IMapper mapper,IConfiguration config,ILogger logger):base(db,mapper, config)
        public AuthService(IConfiguration _config, ILogger _logger, ApplicationDbContext _db_context, IEmailService emailService, IBaseService<Korisnik, UpsertKorisnikVM> userService, ReportingService reportingService)
        {
            using (var client = new HttpClient())
            {
                _discDocument = client.GetDiscoveryDocumentAsync("https://localhost:7153/.well-known/openid-configuration").Result;
            }
            //this.db = db;
            this.config = _config;
            this.logger = _logger;
            db_context = _db_context;
            this.emailService = emailService;
            this.userService = userService;
            this.reportingService = reportingService;
        }
        public async Task<TokenResponse> GetToken(string scope)
        {
            // var IdentityServerSettings = config["IdentityServerSettings"];
            using (var client = new HttpClient())
            {
                var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = _discDocument.TokenEndpoint,
                    ClientId = "web.client",
                    Scope = scope,
                    ClientSecret = "SuperSecretPassword",
                    GrantType = "client_credentials"

                });
                if (tokenResponse.IsError)
                {
                    throw new Exception("Token Error");
                }
                return tokenResponse;
            }
        }
        public LoginRespons LoginManagement(LoginRequest request)
        {
            User user = null;

            try
            {
                user = db_context.radnici.Where(x => x.username == request.username && x.password == request.password).First(); 
            }
            catch (Exception err)
            {
                user = null;
            }

            var respons = new LoginRespons();

            if (user != null)
            {
                var ids4_token_respons = GetToken("cinestar_api.read");
                respons.issued = DateTime.Now;
                respons.token = ids4_token_respons.Result.AccessToken;
                respons.expiresIn = ids4_token_respons.Result.ExpiresIn;
                respons.error = "x";
                respons.id = user.Id;
                respons.level = 1;
            }
            else
            {
                respons.error = "Kredencijali koje ste unijeli nisu tacni." +
                    "Molim vas da obratite pažnju pri ponovnom unosu vaših kredencijala.";
            }

            return respons;
        }

        public LoginRespons Login(LoginRequest request)
        {
            User user = null;

            try
            {
                user = db_context.korisnici.Where(x => x.username == request.username && x.password == request.password).First();

                //user = db_context.radnici.Where(x => x.username == request.username && x.password == request.password).First(); provjera za radnika

            }
            catch (Exception err)
            {
                user = null;
            }

            var respons = new LoginRespons();

            if (user != null)
            {
                var ids4_token_respons = GetToken("cinestar_api.read");
                respons.issued = DateTime.Now;
                respons.token = ids4_token_respons.Result.AccessToken;
                respons.expiresIn = ids4_token_respons.Result.ExpiresIn;
                respons.error = "x";
                respons.id = user.Id;
                respons.level = 1;

            }
            else
            {
                respons.error = "Korisnicko ime ili lozinka nisu tacne. Molimo unesite vaše kredencijale ponovo.";
            }

            return respons;
        }

        public string Register(RegisterRequest req)
        {
            var mail = new ConfirmMailKorisnik() { issuedConfCode = "123456" };

            var resp = db_context.confirmMailKorisnik.Add(mail);

            db_context.SaveChanges();

            Korisnik newUser = new Korisnik();
                newUser.email = req.email;
                newUser.confMailXkorisnici = mail;
                newUser.confMailXkorisniciId = resp.Entity.id;
                newUser.gradId = req.cityId;
                newUser.b_date = req.bdate;
                newUser.broj_telefona = req.broj_telefona;
                newUser.datum_kreiranja_racuna = DateTime.Now;
                newUser.ime_prezime = req.ime_prezime;
                newUser.password = req.password;
                newUser.spol = req.gender;
                newUser.username = req.username;
                newUser.confirmed = 0;


                db_context.korisnici.Add(newUser);

                db_context.SaveChanges();

                reportingService.NotifyClients();

                try
                {
                    emailService.SendEmail(new Mail(req.email, "Konfirmacijski mail od Cinestara!", "Ovo je vaš konfirmacijski kod : "+ mail.issuedConfCode+"\nAko ovo niste vi molim vas da ignorišete mail!", newUser.ime_prezime));
                    return $"{newUser.Id}";
                }
                catch (Exception err)
                {
                    return err.InnerException.Message;
                }
            

        }

        public async Task<string> ConfirmUser(ConfirmationRequest req)
        {

            var users = db_context.korisnici.Where(x => x.Id == req.userId);
            var korisnik = users.First();
            if (korisnik.confirmed == 1)
                return System.Text.Json.JsonSerializer.Serialize(new { message = "Vec ste potvrdili korisnika." });


            if (users.Count() != 0)
            {
                var confCode = db_context.confirmMailKorisnik.Where(x => x.id == korisnik.confMailXkorisniciId).First().issuedConfCode;

                if (req.userCode == confCode)
                {
                    korisnik.confirmed = 1;

                    db_context.SaveChanges();

                    return System.Text.Json.JsonSerializer.Serialize(new { message = "You have confirmed user sucessfully"});
                }
                else
                    return System.Text.Json.JsonSerializer.Serialize(new { message = "Uneseni kod :  " + req.userCode+ " nije dobar, provjerite vaš unos i mail koji ste primili." });

            }
            else
            {
                return System.Text.Json.JsonSerializer.Serialize(new { message = "User doesnt match, somthing went wrong!" });

            }
        }
    }
}
