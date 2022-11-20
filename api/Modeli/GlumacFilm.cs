using System;
using System.Collections.Generic;
using System.Text;

namespace Modeli
{
    public class GlumacFilm
    {
        public int id { get; set; }
        public int glumacId { get; set; }
        //ko je glumio
        public Glumac glumac { get; set; }
        //u kojem je filmu glumio
        public int filmId { get; set; }
        public Film film { get; set; }
    }
}
