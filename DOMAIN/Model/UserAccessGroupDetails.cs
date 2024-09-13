namespace DOMAIN.Model;

public class UserAccessGroupDetails
{
    public int Id { get; set; }
    // User
    public string UserId { get; set; }
    public User User { get; set; }

    // AccessGroupAction
    public int AccessGroupActionId { get; set; }
    public AccessGroupAction AccessGroupAction { get; set; }
}