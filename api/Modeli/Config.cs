using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Modeli
{
    public class Config
    {
        public static string AplikacijURL = "https://localhost:44383/";

        public static string Slike => "slike/";
        public static string SlikeURL => AplikacijURL + Slike;
        public static string SlikeFolder => "wwwroot/" + Slike;
    }
}
