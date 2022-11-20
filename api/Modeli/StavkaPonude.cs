using System;
using System.Collections.Generic;
using System.Text;

namespace Modeli
{
    public class StavkaPonude
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public DateTime datumPocetka { get; set; }
        public DateTime datumZavrsetka { get; set; }
        public double ukupnaCijena { get; set; }

        //potjece iz ponude
        public int ponudaId { get; set; }
        public Ponuda ponude { get; set; }

    }
}
