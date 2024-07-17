
namespace DOMAIN.Model;

public class TableObject
{
    public int Id { get; set; }
    public string Uacs { get; set; }
    public string AccountName { get; set; }
    // Fk Object
    public int? ParentId { get; set; }
    public TableObject? Parent { get; set; }

    // Fk AccountGroup
    public int AccountGroupId { get; set; }
    public AccountGroup AccountGroup { get; set; }

}