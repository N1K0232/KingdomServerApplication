using AutoMapper;
using KingdomServerManager.Shared.Models;
using KingdomServerManager.Shared.Models.Requests;
using ServerLogEntity = KingdomServerManager.DataAccessLayer.Entities.ServerLog;

namespace KingdomServerManager.BusinessLayer.MapperProfiles;

public class ServerLogProfile : Profile
{
    public ServerLogProfile()
    {
        CreateMap<ServerLogEntity, ServerLog>();
        CreateMap<SaveLogRequest, ServerLogEntity>();
    }
}