using System;
using System.Collections.Generic;
using System.Text;

namespace Modeli.ViewModels
{
    public class FilmFullVm
    {
        public int Id { get; set; }
        public Film film { get; set; }
        public List<Glumac> glumci { get; set; }
        public List<Projekcija> projekcije { get; set; }
    }
}
