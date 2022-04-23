using KingdomServerManager.DataAccessLayer.Entities.Common;
using KingdomServerManager.Shared.Models.Enums;

namespace KingdomServerManager.DataAccessLayer.Entities;

public class ServerLog : BaseEntity
{
    public Guid IdUser { get; set; }
    public User User { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime LogDate { get; set; }
    public LogType LogType { get; set; }
}