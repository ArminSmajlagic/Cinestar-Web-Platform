using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modeli.ViewModels
{
    public class FilmAddVm
    {
        public string _naziv { get; set; }
        public string _zanr { get; set; }
       
        public int _detaljiFilmaId { get; set; }
        public string _slikaUrl { get; set; }
        //public IFormFile _slikaUrl { get; set; }
        
        //public string _trajanje { get; set; }
        //public DateTime _datumObjave { get; set; }
        //public string _trailer { get; set; }

    }
}
