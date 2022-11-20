using System;
using System.Collections.Generic;
using System.Text;

namespace Modeli
{
    public class Dvorana
    {
        public int id { get; set; }
        public int brojDvorane { get; set; }
        public int brojSjedista { get; set; }

        //dvorana u kinu
        public int kinoId { get; set; }
        public Kino kino { get; set; }
    }
}
