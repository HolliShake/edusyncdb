namespace DOMAIN.Model;

public class AccessListAction
{
    public int Id { get; set; }
    public string Action { get; set; }

    // Fk AccessList
    public int AccessListId { get; set; }
    public AccessList AccessList { get; set; }
}