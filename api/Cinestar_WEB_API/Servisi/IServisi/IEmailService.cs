using Modeli.MailModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servisi.IServisi
{
    public interface IEmailService
    {
        void SendEmail(Mail mail);
    }
}
