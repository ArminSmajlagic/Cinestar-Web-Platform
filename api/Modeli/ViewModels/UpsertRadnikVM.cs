using System;
using System.Collections.Generic;
using System.Text;

namespace Modeli.ViewModels
{
    public class UpsertRadnikVM
    {
        public int Id { get; set; }
        public string ime_prezime { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public DateTime b_date { get; set; }
        public string password { get; set; }
        public int broj_telefona { get; set; }
        public int gradId { get; set; }
        //dolazi iz grada
        public int spol { get; set; }
        public string jmbg { get; set; }
        public string datum_uposljenja { get; set; }
        public string strucnaSprema { get; set; }
        public int plata { get; set; }
        //on je vrsta radnika
        public int vrstaRadnikaId { get; set; }
    }
}
