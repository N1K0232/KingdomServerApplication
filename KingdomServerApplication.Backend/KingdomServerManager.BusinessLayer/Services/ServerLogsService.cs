using AutoMapper;
using KingdomServerManager.DataAccessLayer;
using KingdomServerManager.Shared.Models;
using KingdomServerManager.Shared.Models.Requests;
using Microsoft.EntityFrameworkCore;

using Entities = KingdomServerManager.DataAccessLayer.Entities;

namespace KingdomServerManager.BusinessLayer.Services;

public class ServerLogsService : IServerLogsService
{
    private readonly IUsersService usersService;
    private readonly IDataContext dataContext;
    private readonly IMapper mapper;

    public ServerLogsService(IUsersService usersService, IDataContext dataContext, IMapper mapper)
    {
        this.usersService = usersService;
        this.dataContext = dataContext;
        this.mapper = mapper;
    }

    public async Task DeleteAsync(Guid id)
    {
        var dbLog = await dataContext.GetAsync<Entities.ServerLog>(id);
        dataContext.Delete(dbLog);
        await dataContext.SaveAsync();
    }
    public async Task<ServerLog> GetAsync(Guid id)
    {
        var dbLog = await dataContext.GetAsync<Entities.ServerLog>(id);
        var user = await usersService.GetAsync(dbLog.IdUser);
        var log = mapper.Map<ServerLog>(dbLog);
        log.User = user;
        return log;
    }
    public async Task<List<ServerLog>> GetUserLogAsync(Guid idUser)
    {
        var query = dataContext.GetData<Entities.ServerLog>();
        var dbLogs = await query.Where(l => l.IdUser == idUser).ToListAsync();
        var logs = new List<ServerLog>();

        foreach (var dbLog in dbLogs)
        {
            var user = await usersService.GetAsync(dbLog.IdUser);
            var log = mapper.Map<ServerLog>(dbLog);
            log.User = user;
            logs.Add(log);
        }

        return logs;
    }
    public async Task<ServerLog> SaveAsync(SaveLogRequest request)
    {
        var query = dataContext.GetData<Entities.ServerLog>(trackingChanges: true);
        var dbLog = await query.Where(l => l.Id == request.Id).FirstOrDefaultAsync();

        if (dbLog == null)
        {
            dbLog = mapper.Map<Entities.ServerLog>(request);
            dataContext.Insert(dbLog);
        }
        else
        {
            mapper.Map(request, dbLog);
            dbLog.LastModifiedDate = DateTime.UtcNow;
        }

        await dataContext.SaveAsync();

        var savedLog = mapper.Map<ServerLog>(dbLog);
        var user = await usersService.GetAsync(dbLog.IdUser);
        savedLog.User = user;
        return savedLog;
    }
}