using MimeKit;
using Services1.Shared;
using System.Net;
//using System.Net.Mail;
using MailKit.Security;
using MailKit.Net.Smtp;

namespace Services1.Server.Services
{
    internal class EmailService : IEmailService
    {
        private readonly string EmailHost = "smtp.gmail.com";
        private readonly string EmailUserName = "24x7services.check@gmail.com";
        private readonly string EmailPassword = "24x7services";

        //public void sendCodeEmail(string to, string s)
        //{
        //    string from, pass, mail;
        //    //string[] s1 = sql.getSystemEmail();

        //    //from = s1[0];
        //    //pass = s1[1];
        //    from = "24x7services.check@gmail.com";
        //    pass = "24x7services";
        //    mail = "Your Verification code to change password\n\n";

        //    MailMessage message = new MailMessage();
        //    message.To.Add("ravishanka.yasas@gmail.com");
        //    message.From = new MailAddress(from);
        //    message.Body = mail;
        //    message.Subject = "Password Change Verification";
        //    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
        //    smtp.EnableSsl = false;
        //    smtp.Port = 587;
        //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    smtp.Credentials = new NetworkCredential(from, pass);

        //    try
        //    {

        //        smtp.Send(message);
        //        //MessageBox.Show("Email send successfully", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        //MessageBox.Show(ex.Message);

        //    }
        //}

        //public void sendEmail(string to, string from, string subject, string mail)
        //{
        //    string pass = ""; /*sql.getSystemEmailPassword(from);*/

        //    MailMessage message = new MailMessage();
        //    message.To.Add(to);
        //    message.From = new MailAddress(from);
        //    message.Body = mail;
        //    message.Subject = subject;
        //    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
        //    smtp.EnableSsl = true;
        //    smtp.Port = 587;
        //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    smtp.Credentials = new NetworkCredential(from, pass);

        //    try
        //    {
        //        smtp.Send(message);
        //        //MessageBox.Show("Email send successfully", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);

        //    }
        //}

        void IEmailService.SendEmail(EmailMessage em)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(EmailUserName));
            email.To.Add(MailboxAddress.Parse(em.to));
            email.Subject = em.subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = em.body };

            using var smtp = new SmtpClient();
            smtp.Connect(EmailHost, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(EmailUserName, EmailPassword);
            smtp.Send(email);
            smtp.Disconnect(true);

        }
    }
}
