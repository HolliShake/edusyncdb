using System.ComponentModel.DataAnnotations;
using APPLICATION.Dto.AccessGroup;

namespace APPLICATION.Dto.AccessGroupAction;
public class GetAccessGroupActionDto
{
    public int Id { get; set; }
    public string Action { get; set; }

    // Fk AccessGroup
    public int AccessGroupId { get; set; }
    public GetAccessGroupDto AccessGroup { get; set; }
}
