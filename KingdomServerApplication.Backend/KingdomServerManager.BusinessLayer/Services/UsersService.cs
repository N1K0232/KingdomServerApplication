using AutoMapper;
using KingdomServerManager.DataAccessLayer;
using KingdomServerManager.Shared.Models;
using KingdomServerManager.Shared.Models.Requests;
using Microsoft.EntityFrameworkCore;
using Entities = KingdomServerManager.DataAccessLayer.Entities;

namespace KingdomServerManager.BusinessLayer.Services;

public class UsersService : IUsersService
{
    private readonly IRolesService rolesService;
    private readonly IDataContext dataContext;
    private readonly IMapper mapper;

    public UsersService(IRolesService rolesService, IDataContext dataContext, IMapper mapper)
    {
        this.rolesService = rolesService;
        this.dataContext = dataContext;
        this.mapper = mapper;
    }

    public async Task DeleteAsync(Guid id)
    {
        var dbUser = await dataContext.GetAsync<Entities.User>(id);
        dataContext.Delete(dbUser);
        await dataContext.SaveAsync();
    }
    public async Task<User> GetAsync(string userName)
    {
        var query = dataContext.GetData<Entities.User>();
        var dbUser = await query.Where(u => u.UserName == userName).FirstOrDefaultAsync();
        var role = await rolesService.GetAsync(dbUser.IdRole);
        var user = mapper.Map<User>(dbUser);
        user.Role = role;
        return user;
    }
    public async Task<User> GetAsync(Guid id)
    {
        var dbUser = await dataContext.GetAsync<Entities.User>(id);
        var role = await rolesService.GetAsync(dbUser.IdRole);
        var user = mapper.Map<User>(dbUser);
        user.Role = role;
        return user;
    }
    public async Task<User> SaveAsync(SaveUserRequest request)
    {
        var query = dataContext.GetData<Entities.User>(trackingChanges: true);
        var dbUser = await query.Where(u => u.Id == request.Id).FirstOrDefaultAsync();

        if (dbUser == null)
        {
            if (string.IsNullOrEmpty(request.ServerUserName))
            {
                request.ServerUserName = request.UserName;
            }
            dbUser = mapper.Map<Entities.User>(request);
            dataContext.Insert(dbUser);
        }
        else
        {
            mapper.Map(request, dbUser);
            dbUser.LastModifiedDate = DateTime.UtcNow;
        }

        await dataContext.SaveAsync();

        var savedUser = mapper.Map<User>(dbUser);
        var role = await rolesService.GetAsync(dbUser.IdRole);
        savedUser.Role = role;
        return savedUser;
    }
}