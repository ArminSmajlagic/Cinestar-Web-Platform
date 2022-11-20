using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modeli.ViewModels
{
    public class AddImageVM
    {
        public IFormFile image { set; get; }
    }
}
