using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Modeli
{

    public class Korisnik : User
    {
        public DateTime datum_kreiranja_racuna { get; set; }
        public int confirmed { get; set; }
        public int confMailXkorisniciId { get; set; }
        public ConfirmMailKorisnik confMailXkorisnici { get; set; }
    }
}
