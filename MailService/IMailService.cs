using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailService
{
    public interface IMailService
    {
        /// <summary>
        /// U can send mail by using this Send method
        /// </summary>
        /// <param name="to"></param>
        /// <param name="title"></param>
        /// <param name="body">Body of email can render HTML !</param>
        void Send( string title, string body, List<string> tos, List<string> ccs=null);
    }
}
