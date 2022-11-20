using System;
using System.Collections.Generic;
using System.Text;

namespace Modeli
{
    public class Sjediste
    {
        public int id { get; set; }
        public int red { get; set; }
        public int kolona { get; set; }
        public int dvoranaId { get; set; }
        public Dvorana dvorana { get; set; }

    }
}
