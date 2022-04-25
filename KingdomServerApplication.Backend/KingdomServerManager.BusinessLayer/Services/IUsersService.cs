using KingdomServerManager.Shared.Models;
using KingdomServerManager.Shared.Models.Requests;

namespace KingdomServerManager.BusinessLayer.Services;

public interface IUsersService
{
    Task DeleteAsync(Guid id);
    Task DeleteAsync(string userName);
    Task<User> GetAsync(string userName);
    Task<User> GetAsync(Guid id);
    Task<User> SaveAsync(SaveUserRequest request);
}