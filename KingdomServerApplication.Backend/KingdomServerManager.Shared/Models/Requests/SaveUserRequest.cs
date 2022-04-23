using KingdomServerManager.Shared.Models.Common;

namespace KingdomServerManager.Shared.Models.Requests;

#nullable enable
public class SaveUserRequest : BaseRequestObject
{
    public string UserName { get; set; } = "";
    public string? ServerUserName { get; set; }
    public Guid IdRole { get; set; }
}
#nullable disable