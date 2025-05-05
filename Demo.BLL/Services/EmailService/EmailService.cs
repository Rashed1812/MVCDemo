using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models.IdentityModel;

namespace Demo.BLL.Services.EmailService
{
    public class EmailService : IEmailService
    {
        public void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com",587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("abdelra7man.rashed@gmail.com", "pprbecrbauzpgfdz");
            client.Send("abdelra7man.rashed@gmail.com",email.To,email.Subject,email.Body);
        }
    }
}
