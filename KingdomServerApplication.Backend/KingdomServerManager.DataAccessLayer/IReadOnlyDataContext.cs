using KingdomServerManager.DataAccessLayer.Entities.Common;

namespace KingdomServerManager.DataAccessLayer;

public interface IReadOnlyDataContext
{
    IQueryable<T> GetData<T>(bool ignoreQueryFilters = false, bool trackingChanges = false) where T : BaseEntity;
    ValueTask<T> GetAsync<T>(params object[] keyValues) where T : BaseEntity;
}