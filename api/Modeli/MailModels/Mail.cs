using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modeli.MailModels
{
    public class Mail
    {      
        public MailboxAddress To { get; set; }

        public string Subject { get; set; }
        public string Content { get; set; }
        public string name { get; set; }

        public Mail(string to, string subj, string cont,string name)
        {
            To = new MailboxAddress(name, to);
            Subject = subj;
            Content = cont;
            this.name = name;
        } 
    }
}
