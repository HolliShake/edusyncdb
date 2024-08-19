namespace DOMAIN.Model;

public class AccessList
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public bool IsGroup { get; set; }
    public int? ReferenceId { get; set; }
    public AccessListType Type { get; set; } = AccessListType.GLOBAL;

    // Fk AccessList
    public int? ParentId { get; set; }
    public AccessList Parent { get; set; }

    // Nav
    public virtual ICollection<AccessListAction> AccessListActions { get; set; }

    // Nav
    public virtual ICollection<AccessList> Children { get; set; }
}