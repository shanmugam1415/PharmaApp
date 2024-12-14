using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using PharmaApp.Application.Repositories;
using PharmaApp.Domain.Entities;
using PharmaApp.Domain.Entities.UserEntities;
using PharmaApp.Domain.Enum;
using PharmaApp.Domain.model;
using PharmaApp.Infrastructure.Context;

namespace PharmaApp.Infrastructure.Repositories;

public class MasterLookUpRepository : BaseRepository<MasterLookUp>, IMasterLookUpRepository
{
    private readonly IConfiguration _config;
    private readonly PharmaDbContext _context;

    public MasterLookUpRepository(PharmaDbContext context, IConfiguration config ): base(context)
    {
        _config = config;
        _context = context;
    }
    

    public async Task<List<MasterLookUp>> GetLocationsAsync()
    {
        var query= _dbSet.Where(x=>x.Type==EnumTypes.Location.ToString()).AsNoTracking();
        return await query.ToListAsync();
    }
    public async Task<List<MasterLookUp>> GetRegionsAsync()
    {
        var query = _dbSet.Where(x => x.Type == EnumTypes.Region.ToString()).AsNoTracking();
        return await query.ToListAsync();
    }
    public async Task<List<MasterLookUp>> GetStatesAsync()
    {
        var query = _dbSet.Where(x => x.Type == EnumTypes.State.ToString()).AsNoTracking();
        return await query.ToListAsync();
    }

}
