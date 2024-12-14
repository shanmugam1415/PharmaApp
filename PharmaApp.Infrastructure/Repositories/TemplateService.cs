namespace PharmaApp.Infrastructure.Repositories
{
    using Microsoft.Extensions.Configuration;
    using PharmaApp.Application.Common.Enum;
    using PharmaApp.Application.Common.Utility;
    using PharmaApp.Application.Repositories;
    using static Org.BouncyCastle.Math.EC.ECCurve;

    public class TemplateService : ITemplateService
    {
        private readonly IConfiguration _config;

        public TemplateService(IConfiguration config)
        {
            _config = config;
        }


        public async Task<string> GetMailTempate(string toEmail, string subject, string body, string url = null, string templateName = null, MailBody userDetails = null)
        {

            return "";

        }
    }

}
