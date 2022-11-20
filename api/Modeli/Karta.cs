using System;
using System.Collections.Generic;
using System.Text;

namespace Modeli
{
    public class Karta
    {
        public int id { get; set; }
        public float cijena { get; set; }
        public int projekcijaId { get; set; }
        public Projekcija projekcija { get; set; }
        public int sjedisteId { get; set; }
        public Sjediste sjediste { get; set; }
        public int? racunId { get; set; }
        public Racun racun { get; set; }

    }
}
