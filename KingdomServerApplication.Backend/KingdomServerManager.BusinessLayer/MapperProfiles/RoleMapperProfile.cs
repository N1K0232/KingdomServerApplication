using AutoMapper;
using KingdomServerManager.Shared.Models;
using RoleEntity = KingdomServerManager.DataAccessLayer.Entities.Role;

namespace KingdomServerManager.BusinessLayer.MapperProfiles;

public class RoleMapperProfile : Profile
{
    public RoleMapperProfile()
    {
        CreateMap<RoleEntity, Role>();
    }
}