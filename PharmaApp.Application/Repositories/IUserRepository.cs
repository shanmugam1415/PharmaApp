using PharmaApp.Domain.Entities.UserEntities;
using PharmaApp.Domain.model;
using PharmaApp.Domain.model.DTO;

namespace PharmaApp.Application.Repositories;

public interface IUserRepository : IBaseRepository<UserProfile>
{

    Task<UserProfileResponce> GetByUsernameAndPasswordAsync(string username, string password);
    Task<UserProfile> GetByEmailAsync(string email);
    Task<bool> VerifyTwoFactorCodeAsync(string email,int userId, string code);
    Task<UserProfile> GetByIdAsync(int Id);
    Task<int> Update(UserProfile userProfile);
}