using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaApp.Application.Common.Utility;

namespace PharmaApp.Application.Repositories
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body, string url = null,string templateName = null, MailBody userDetails =null);
    }
}
