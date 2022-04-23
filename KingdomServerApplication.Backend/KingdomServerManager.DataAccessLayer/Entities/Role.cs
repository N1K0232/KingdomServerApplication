using KingdomServerManager.DataAccessLayer.Entities.Common;

namespace KingdomServerManager.DataAccessLayer.Entities;

public class Role : BaseEntity
{
    public string Name { get; set; }
    public string Color { get; set; }
    public List<User> Users { get; set; }
}