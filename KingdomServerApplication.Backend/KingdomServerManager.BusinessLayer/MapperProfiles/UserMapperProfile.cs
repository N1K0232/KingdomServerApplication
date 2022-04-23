using AutoMapper;
using KingdomServerManager.Shared.Models;
using KingdomServerManager.Shared.Models.Requests;
using UserEntity = KingdomServerManager.DataAccessLayer.Entities.User;

namespace KingdomServerManager.BusinessLayer.MapperProfiles;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<UserEntity, User>();
        CreateMap<SaveUserRequest, UserEntity>();
    }
}