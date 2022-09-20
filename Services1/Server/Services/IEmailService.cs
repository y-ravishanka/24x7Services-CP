using Services1.Shared;

namespace Services1.Server.Services
{
    internal interface IEmailService
    {
        //void sendCodeEmail(string to, string s);
        //void sendEmail(string to, string from, string subject, string mail);

        void SendEmail(EmailMessage em);
    }
}
