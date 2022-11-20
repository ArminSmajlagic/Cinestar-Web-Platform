using System;
using System.Collections.Generic;
using System.Text;

namespace Modeli
{
    public class Kasa
    {
        public int id { get; set; }
        public double stanje_kase { get; set; }
        public bool aktivna { get; set; }
        //nalazi se u kinu
        public int kinoId { get; set; }
        public Kino kino { get; set; }

    }
}
