using System;
using System.Collections.Generic;
using System.Text;

namespace Modeli
{
    public class DetaljiFilma
    {
        public int id { get; set; }
        public string  trajanje { get; set; }
        public DateTime datumObjave { get; set; }
        public string trailer { get; set; }
        public string trailerID { get; set; }
    }
}
