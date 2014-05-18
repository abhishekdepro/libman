using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace LibraryManager
{
    public class mail
    {
        public void recoverpassword(string to, string password)
        {
            MailMessage mail = new MailMessage();

            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            // enter password here
            smtpServer.Credentials = new System.Net.NetworkCredential("reset.libman", "libman.azurewebsites");
            smtpServer.Port = 587; // Gmail works on this port
            smtpServer.EnableSsl = true;
            mail.From = new MailAddress("myemail@gmail.com");
            mail.To.Add(to);
            mail.Subject = "Password recovery from Library Manager";
            mail.Body = "Your old password was: " + password + Environment.NewLine+ " kindly enter it and login here: http://libman.azurewebsites.net/Account/Login";

            smtpServer.Send(mail);
        }
    }
}