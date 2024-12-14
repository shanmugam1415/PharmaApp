using Sentry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaApp.Domain.Entities;
using PharmaApp.Domain.Entities.UserEntities;

namespace PharmaApp.Application.Repositories
{
    public interface ITokenService
    {
        string GenerateToken(UserProfile user);
    }
}
