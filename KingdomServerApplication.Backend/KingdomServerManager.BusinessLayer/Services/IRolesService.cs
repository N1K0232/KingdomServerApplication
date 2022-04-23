using KingdomServerManager.Shared.Models;

namespace KingdomServerManager.BusinessLayer.Services;

public interface IRolesService
{
    Task<Role> GetAsync(Guid idRole);
}