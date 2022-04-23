using KingdomServerManager.Shared.Models.Common;

namespace KingdomServerManager.Shared.Models;

public class User : BaseObject
{
    public string UserName { get; set; }
    public string ServerUserName { get; set; }
    public Role Role { get; set; }
}