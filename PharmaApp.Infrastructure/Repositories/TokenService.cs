using Microsoft.Extensions.Configuration;
using PharmaApp.Application.Repositories;
using PharmaApp.Domain.Entities.UserEntities;

namespace PharmaApp.Infrastructure.Repositories
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(UserProfile user)
        {
            throw new NotImplementedException();
        }
    }

}
