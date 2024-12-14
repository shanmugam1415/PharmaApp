using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sentry;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Security.Claims;
using System.Text;
using PharmaApp.Application.Repositories;
using PharmaApp.Domain.Entities.UserEntities;
using PharmaApp.Domain.model;
using PharmaApp.Domain.model.DTO;
using PharmaApp.Infrastructure.Context;

namespace PharmaApp.Infrastructure.Repositories;

public class UserRepository : BaseRepository<UserProfile>, IUserRepository
{
    private readonly IConfiguration _config;
    private readonly PharmaDbContext _context;
    private readonly IEmailService _emailService;
    private readonly IMapper _mapper;

    public UserRepository(PharmaDbContext context, IConfiguration config, IEmailService emailService
        , IMapper mapper) : base(context)
    {
        _config = config;
        _context = context;
        _emailService = emailService;
        _mapper = mapper;
    }
    private readonly Dictionary<string, (string Token, DateTime Expiry)> _twoFactorTokens = new();

    public async Task<UserProfile> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.EmailAddress == email);
    }

    public async Task<UserProfileResponce> GetByUsernameAndPasswordAsync(string username, string password)
    {
        var userDetails = await GetUserProfile(username, password);
        if (userDetails == null)
        {
            throw new Exception("Invalid UserName or Password");
        }

        var twoFactorToken = GenerateTwoFactorToken();
        await SaveTwoFactorTokenAsync(userDetails.Id, userDetails.EmailAddress, twoFactorToken);
        string body = "Your verification code is: " + twoFactorToken + "It will expire in 5 minutes";

        await _emailService.SendEmailAsync(username, "Two Factore Authentication", body);


        var token = GenerateToken(userDetails);

        return new UserProfileResponce
        {
            Id = userDetails.Id,
            Token = token,
            Email = userDetails.EmailAddress,
            FirstName = userDetails.FirstName,
            LastName = userDetails.LastName,
            RoleId = userDetails.RoleId,
            UserStatusId = userDetails.StatusId,

        };
    }

    private async Task<UserProfile> GetUserProfile(string username, string password)
    {

        var user = await _context.UserProfiles.FirstOrDefaultAsync(
            x => x.EmailAddress.ToLower() == username.ToLower() && x.Password == password);

        return user;
    }

    private string GenerateToken(UserProfile user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role,"Admin"),
            new Claim(ClaimTypes.Name, user.FirstName),
        };

        var token = new JwtSecurityToken(
            _config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private string GenerateTwoFactorToken()
    {
        var random = new Random();
        return random.Next(100000, 999999).ToString();
    }

    private async Task SaveTwoFactorTokenAsync(int userId, string emailId, string token)
    {
        var expiryTime = DateTime.UtcNow.AddMinutes(5);

        //Implementation to store verification code

        await _context.SaveChangesAsync();
    }


    public async Task<bool> VerifyTwoFactorCodeAsync(string emailId, int userId, string code)
    {
        //Implementation of verification code
        return false;
    }


    public async Task<UserProfile> GetByIdAsync(int Id)
    {
        return await _context.UserProfiles.FirstOrDefaultAsync(x => x.Id == Id);
    }

    public async Task<int> Update(UserProfile userProfile)
    {
        _context.UserProfiles.Update(userProfile);
        var result = await _context.SaveChangesAsync();
        return result;
    }

}
