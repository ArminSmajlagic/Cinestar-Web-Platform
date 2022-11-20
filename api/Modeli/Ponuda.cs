using System;
using System.Collections.Generic;
using System.Text;

namespace Modeli
{
    public class Ponuda
    {
        public int id { get; set; }
        public string vrsta_ponude { get; set; }
        public DateTime pocetakPonude { get; set; }
        public int trajanjePonude { get; set; }
        public DateTime krajPonude {
            get { 
                return pocetakPonude.AddDays(trajanjePonude); 
            }
            set { 
                pocetakPonude = value;
            } 
        }

        //kreira ponudu radnik
        public int radnikId { get; set; }
        public Radnik radnik { get; set; }
    }
}
