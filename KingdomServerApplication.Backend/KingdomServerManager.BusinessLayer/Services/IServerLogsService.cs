using KingdomServerManager.Shared.Models;
using KingdomServerManager.Shared.Models.Requests;

namespace KingdomServerManager.BusinessLayer.Services
{
    public interface IServerLogsService
    {
        Task DeleteAsync(Guid id);
        Task<ServerLog> GetAsync(Guid id);
        Task<List<ServerLog>> GetUserLogAsync(Guid idUser);
        Task<ServerLog> SaveAsync(SaveLogRequest request);
    }
}
