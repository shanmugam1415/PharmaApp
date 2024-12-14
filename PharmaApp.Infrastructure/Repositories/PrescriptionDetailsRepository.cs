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

public class PrescriptionDetailsRepository : BaseRepository<PrescriptionDetails>, IPrescriptionDetailsRepository
{
    private readonly IConfiguration _config;
    private readonly PharmaDbContext _context;

    public PrescriptionDetailsRepository(PharmaDbContext context, IConfiguration config ): base(context)
    {
        _config = config;
        _context = context;
    }
    public async Task AddPrescriptionDetails(List<PrescriptionDetails> prescriptionDetails)
    {
        await _context.AddRangeAsync(prescriptionDetails);
    }


}
