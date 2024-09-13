using APPLICATION.Dto.AccessGroupAction;
using APPLICATION.Dto.User;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.UserAccessGroupDetails;
public class GetUserAccessGroupDetailsDto
{
    public int Id { get; set; }
    // User
    public string UserId { get; set; }
    public GetUserOnlyDto User { get; set; }

    // AccessGroupAction
    public int AccessGroupActionId { get; set; }
    public GetAccessGroupActionDto AccessGroupAction { get; set; }
}
