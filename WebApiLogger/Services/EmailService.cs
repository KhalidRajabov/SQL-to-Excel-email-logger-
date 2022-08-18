using Grpc.Core;
using System.Net.Mail;
using WebApiLogger.Interfaces;

namespace WebApiLogger.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool SendEmail(string email, string subject, string message, string file, byte[] bytes)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(_configuration.GetSection("MySettings:Mail").Value);
            mail.Attachments.Add(new Attachment(new MemoryStream(bytes), file));
            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(_configuration.GetSection("MySettings:Mail").Value, _configuration.GetSection("MySettings:Password").Value);

            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;

            
                try
                    {
                        mail.To.Add(new MailAddress(email));


                        client.Send(mail);

                    }
                catch (System.Exception)
                    {
    
    
                    }
                return false;

            }
    }
}
