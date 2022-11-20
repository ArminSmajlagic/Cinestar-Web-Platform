using System;
using System.Collections.Generic;
using System.Text;

namespace Modeli.AuthModeli
{
    public class RegisterRequest
    {
        public string ime_prezime { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int broj_telefona { get; set; }
        public DateTime bdate { get; set; }
        public int cityId { get; set; }
        public int gender { get; set; }
    }
}
