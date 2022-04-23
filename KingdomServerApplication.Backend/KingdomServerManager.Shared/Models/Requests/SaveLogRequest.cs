using KingdomServerManager.Shared.Models.Common;
using KingdomServerManager.Shared.Models.Enums;

namespace KingdomServerManager.Shared.Models.Requests;

public class SaveLogRequest : BaseRequestObject
{
    public Guid IdUser { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime LogDate { get; set; }
    public LogType LogType { get; set; }
}