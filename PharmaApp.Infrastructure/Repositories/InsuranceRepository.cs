using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using PharmaApp.Application.Repositories;
using PharmaApp.Infrastructure.Context;
using PharmaApp.Domain.Entities;

namespace PharmaApp.Infrastructure.Repositories;

public class InsuranceRepository : BaseRepository<Insurance>, IInsuranceRepository
{
    private readonly IConfiguration _config;
    private readonly PharmaDbContext _context;

    public InsuranceRepository(PharmaDbContext context, IConfiguration config ): base(context)
    {
        _config = config;
        _context = context;
    }
    

}
