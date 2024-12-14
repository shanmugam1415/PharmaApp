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

public class PatientRepository : BaseRepository<Patient>, IPatientRepository
{
    private readonly IConfiguration _config;
    private readonly PharmaDbContext _context;

    public PatientRepository(PharmaDbContext context, IConfiguration config ): base(context)
    {
        _config = config;
        _context = context;
    }
    

    public async Task<Patient> GetPatientByIdAsync(int id)
    {
        
        return await _dbSet.FirstOrDefaultAsync(x=>x.Id==id);
    }

}
