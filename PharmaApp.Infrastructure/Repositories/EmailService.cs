namespace PharmaApp.Infrastructure.Repositories
{
    using Microsoft.Extensions.Configuration;
    using System.Net;
    using System.Net.Mail;
    using PharmaApp.Application.Common.Utility;
    using PharmaApp.Application.Repositories;

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        private readonly ITemplateService _template;
        public EmailService(IConfiguration config, ITemplateService template)
        {
            _config = config;
            _template= template;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body, string url = null, string templateName = null, MailBody userDetails=null)
        {
            try
            {
                var emailSettings = _config.GetSection("EmailSettings");
                var smtpServer = emailSettings["SmtpServer"];
                var port = int.Parse(emailSettings["Port"]);
                var senderEmail = emailSettings["SenderEmail"];
                var senderName = emailSettings["SenderName"];
                var senderPassword = emailSettings["SenderPassword"];
                using (var client = new SmtpClient(smtpServer, port))
                {
                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    client.EnableSsl = true;

                    string templateBody = await  _template.GetMailTempate(toEmail, subject, body, url, templateName, userDetails);
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(senderEmail, senderName),
                        Subject = subject,
                        Body = templateBody,
                        IsBodyHtml = true,

                    };

                    mailMessage.To.Add(toEmail);
                    await client.SendMailAsync(mailMessage);
                   
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
