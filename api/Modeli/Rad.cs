using System;
using System.Collections.Generic;
using System.Text;

namespace Modeli
{
    public class Rad
    {
        public int id { get; set; }

        //kase na kojoj je rađeno
        public int kasaId { get; set; }
        public Kasa kasa { get; set; }

        //radnik koji je radio
        public int radnikId { get; set; }
        public Radnik radnik { get; set; }
        public DateTime vrijemeRada { get; set; }
        public double totalKase { get; set; }

    }
}
