using System;
using System.Collections.Generic;
using System.Text;

namespace Modeli.SearchObjects
{
    public class BaseSearchObject
    {
       public int? id { get; set; }
        public int? page { get; set; }
        public int? pageSize { get; set; }

    }
}
