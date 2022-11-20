using System;
using System.Collections.Generic;
using System.Text;

namespace Modeli.AuthModeli
{
    public class LoginRespons
    {
        public string token { get; set; }
        public int expiresIn { get; set; }
        public DateTime issued { get; set; }
        public string scope { get; set; }
        public string error { get; set; }
        public int id { get; set; }
        public int level { get; set; }
    }
}
