using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeli.AuthModeli
{
    public class ConfirmationRequest
    {
        public int userId { get; set; }
        public string userCode { get; set; }
    }
}
