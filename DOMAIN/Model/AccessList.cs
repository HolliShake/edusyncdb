namespace DOMAIN.Model;

public class AccessList
{
    public int Id { get; set; }
    public string Subject { get; set; }
    // Fk AccessGroup
    public int AccessGroupId { get; set; }
    public AccessGroup AccessGroup { get; set; }
    // Nav
    public virtual ICollection<AccessListAction> AccessListActions { get; set; }
}