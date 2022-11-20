using System;
using System.Collections.Generic;
using System.Text;

namespace Modeli
{
    public class Projekcija
    {
        public int id { get; set; }
        public string dan { get; set; }
        public DateTime vrijemePrikazivanja { get; set; }
        public int vrstaProjekcijeId { get; set; }
        public  VrstaProjekcije vrstaProjekcije { get; set; }
        public int filmId { get; set; }
        public Film film { get; set; }

    }
}
