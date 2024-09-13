
namespace DOMAIN.Model;

public class AccessGroupAction
{
    public int Id { get; set; }
    public string Action { get; set; }

    // Fk AccessGroup
    public int AccessGroupId { get; set; }
    public AccessGroup AccessGroup { get; set; }
}