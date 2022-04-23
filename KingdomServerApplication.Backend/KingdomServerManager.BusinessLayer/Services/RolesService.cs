using AutoMapper;
using KingdomServerManager.DataAccessLayer;
using KingdomServerManager.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Entities = KingdomServerManager.DataAccessLayer.Entities;

namespace KingdomServerManager.BusinessLayer.Services;

public class RolesService : IRolesService
{
    private readonly IReadOnlyDataContext dataContext;
    private readonly IMapper mapper;

    public RolesService(IReadOnlyDataContext dataContext, IMapper mapper)
    {
        this.dataContext = dataContext;
        this.mapper = mapper;
    }

    public async Task<Role> GetAsync(Guid idRole)
    {
        var query = dataContext.GetData<Entities.Role>();
        var dbRole = await query.Where(r => r.Id == idRole).FirstOrDefaultAsync();
        var role = mapper.Map<Role>(dbRole);
        return role;
    }
}