using KingdomServerManager.DataAccessLayer.Configurations;
using KingdomServerManager.DataAccessLayer.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace KingdomServerManager.DataAccessLayer;

public class DataContext : DbContext, IDataContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public void Delete<T>(T entity) where T : BaseEntity
    {
        var set = Set<T>();
        set.Remove(entity);
    }

    public ValueTask<T> GetAsync<T>(params object[] keyValues) where T : BaseEntity
    {
        var set = Set<T>();
        var entity = set.FindAsync(keyValues);
        return entity;
    }

    public IQueryable<T> GetData<T>(bool ignoreQueryFilters = false, bool trackingChanges = false) where T : BaseEntity
    {
        var set = Set<T>().AsQueryable();

        if (ignoreQueryFilters)
        {
            set = set.IgnoreQueryFilters();
        }

        return trackingChanges ?
            set.AsTracking() :
            set.AsNoTracking();
    }

    public void Insert<T>(T entity) where T : BaseEntity
    {
        var set = Set<T>();
        set.Add(entity);
    }

    public Task SaveAsync() => SaveChangesAsync();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ServerLogConfiguration());
    }
}