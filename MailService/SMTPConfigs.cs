using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailService
{
    public class SMTPConfig
    {
        public string OwnerMail { get; set; }
        public string OwnerPassword { get; set; }
        public string Host{ get; set; }
        public string Port{ get; set; }
    }
}
