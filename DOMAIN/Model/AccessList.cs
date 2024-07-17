namespace DOMAIN.Model;

public class AccessList
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public bool IsGroup { get; set; }
    // Nav
    public virtual ICollection<AccessListAction> AccessListActions { get; set; }
}