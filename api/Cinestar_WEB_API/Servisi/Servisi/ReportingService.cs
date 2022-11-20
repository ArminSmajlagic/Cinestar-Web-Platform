using dataBase;
using Microsoft.AspNetCore.SignalR;
using Modeli;
using Modeli.DashboardModels;
using Servisi.HubConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servisi.Servisi
{
    public class ReportingService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IHubContext<ChartsHub> hub;

        public ReportingService(ApplicationDbContext _dbContext, IHubContext<ChartsHub> hub)
        {
            this.hub = hub;
            dbContext= _dbContext;
        }

        public RealTimeReportVM prepareReport()
        {

            RealTimeReportVM report = new RealTimeReportVM();
            var r = new Random();

            report.topUsers = GetTopUsers();
            report.topMovies = GetTopMovies();
            report.topTheaters = GetTopTheatars();

            for (int i = 0; i < 12; i++)
            {
                report.chart1.Add(r.Next(1, 50));
                report.chart2.Add(r.Next(1, 1000));
                report.chart3.Add(r.Next(1, 1000));
            }

            return report;
        }

        public async void NotifyClients()
        {
            var report = prepareReport();

            await hub.Clients.All.SendAsync("transferchartdata", report);
        }

        public List<TopMovie> GetTopMovies()
        {
            List<TopMovie> topMovies = new List<TopMovie>();
            foreach (var ticket in dbContext.karta)
            {

                var projekcija = dbContext.projekcije.Find(ticket.projekcijaId);
                var topMovie = topMovies.Find(x => x.id == projekcija.filmId);

                if (topMovie == null)
                {
                    var movie = dbContext.filmovi.Find(projekcija.filmId);
                    topMovies.Add(new TopMovie() { id = projekcija.filmId, title = movie.naziv, count = 1 });
                }
                else
                {
                    topMovie.count++;
                }

            }

            return topMovies;
        }

        public List<TopUser> GetTopUsers()
        {
            List<TopUser> topUsers = new List<TopUser>();
            foreach (var item in dbContext.racun)
            {
                var topUser = topUsers.Find(x => x.id == item.korisnikId);

                if (topUser == null)
                {
                    var user = dbContext.korisnici.Find(item.korisnikId);
                    topUsers.Add(new TopUser() { id = item.korisnikId, name = user.username, total = item.ukupnaCijena });
                }
                else
                {
                    topUser.total += item.ukupnaCijena;
                }
            }
                return topUsers;
        }

        public List<TopTheatar> GetTopTheatars()
        {
            List<TopTheatar> topTheaters = new List<TopTheatar>();

            foreach (var karta in dbContext.karta)
            {
                var sjediste = dbContext.sjediste.Find(karta.sjedisteId);
                var dvorana = dbContext.dvorana.Find(sjediste.dvoranaId);
                var topKino = topTheaters.Find(x => x.id == dvorana.kinoId);

                if (topKino == null)
                {

                    var kino = dbContext.kino.Find(dvorana.kinoId);
                    var grad = dbContext.grad.Find(kino.gradId);
                    topTheaters.Add(new TopTheatar() { id = kino.id, grad = kino.grad.naziv, visits = 1 });
                }
                else
                {
                    topKino.visits++;
                }
            }
            return topTheaters;

        }
    }
}
