using KingdomServerManager.Shared.Models.Common;
using KingdomServerManager.Shared.Models.Enums;

namespace KingdomServerManager.Shared.Models;

public class ServerLog : BaseObject
{
    public User User { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public LogType LogType { get; set; }
}