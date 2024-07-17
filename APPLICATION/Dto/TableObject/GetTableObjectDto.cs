using APPLICATION.Dto.AccountGroup;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.TableObject;
public class GetTableObjectDto
{
    public int Id { get; set; }
    public string Uacs { get; set; }
    public string AccountName { get; set; }
    // Fk Object
    public int? ParentId { get; set; }
    public GetTableObjectDto? Parent { get; set; }

    // Fk AccountGroup
    public int AccountGroupId { get; set; }
    public GetAccountGroupDto AccountGroup { get; set; }

}
