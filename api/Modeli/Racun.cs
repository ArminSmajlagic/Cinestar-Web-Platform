using System;
using System.Collections.Generic;
using System.Text;

namespace Modeli
{
    public class Racun
    {
        public int id { get; set; }
        public double ukupnaCijena { get; set; }
        public DateTime vrijemeKupovine { get; set; }
        //izdat na kasi
        public int kasaId { get; set; }
        public Kasa kasa { get; set; }
        //kupljeno od stavki sa ponude
        public int? stavkaPonudeId { get; set; }
        public StavkaPonude stavkaPonude { get; set; }
        //izdat korisniku
        public int korisnikId { get; set; }
        public Korisnik korisnik { get; set; }
    }
}
