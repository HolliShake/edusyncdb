using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AccessGroupAction;
public class AccessGroupActionDto
{
    public string Action { get; set; }

    // Fk AccessGroup
    public int AccessGroupId { get; set; }
}
