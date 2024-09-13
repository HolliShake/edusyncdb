using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.UserAccessGroupDetails;
public class UserAccessGroupDetailsDto
{
    // User
    public string UserId { get; set; }

    // AccessGroupAction
    public int AccessGroupActionId { get; set; }
}
