using KingdomServerManager.DataAccessLayer.Entities.Common;

namespace KingdomServerManager.DataAccessLayer.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; }
    public string ServerUserName { get; set; }
    public Guid IdRole { get; set; }
    public Role Role { get; set; }
    public List<ServerLog> ServerLogs { get; set; }
}