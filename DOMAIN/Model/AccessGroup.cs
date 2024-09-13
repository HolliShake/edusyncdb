namespace DOMAIN.Model;

public class AccessGroup
{
    public int Id { get; set; }
    public string AccessGroupName { get; set; }
    // Nav
    public virtual ICollection<AccessGroupAction> AccessGroupActions { get; set; }
}
