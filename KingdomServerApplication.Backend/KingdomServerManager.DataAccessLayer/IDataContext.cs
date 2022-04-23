using KingdomServerManager.DataAccessLayer.Entities.Common;

namespace KingdomServerManager.DataAccessLayer;

public interface IDataContext : IReadOnlyDataContext
{
    void Delete<T>(T entity) where T : BaseEntity;
    void Insert<T>(T entity) where T : BaseEntity;
    Task SaveAsync();
}