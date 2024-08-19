namespace APPLICATION.Dto.UserAccess;

public class UpdateUserAccessDto
{
    public int Id { get; set; }

    public UserAccessUpdateMode Mode { get; set; }

    // Fk User
    public string UserId { get; set; }

    // Fk AccessList
    public int AccessListId { get; set; }

    // FK AccessListAction
    public int AccessListActionId { get; set; }
}