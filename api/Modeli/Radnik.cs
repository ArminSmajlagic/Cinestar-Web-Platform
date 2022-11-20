using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Modeli
{
    public class Radnik : User
    {
        public string jmbg { get; set; }
        public string datum_uposljenja { get; set; }
        public string strucnaSprema { get; set; }
        public int plata { get; set; }

        //on je vrsta radnika
        public int vrstaRadnikaId { get; set; }
        public VrstaRadnika vrstaRadnika { get; set; }


    }

}
