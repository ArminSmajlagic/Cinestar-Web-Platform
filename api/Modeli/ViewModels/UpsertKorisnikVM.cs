using System;
using System.Collections.Generic;
using System.Text;

namespace Modeli.ViewModels
{
    public class UpsertKorisnikVM
    {
        public int Id { get; set; }
        public string ime_prezime { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public DateTime b_date { get; set; }
        public string password { get; set; }
        public int broj_telefona { get; set; }
        public int gradId { get; set; }
        public int spol { get; set; }
        public DateTime datum_kreiranja_racuna { get; set; }
        public int confirmed { get; set; }
        public int confMailXkorisniciId { get; set; }

    }
}
