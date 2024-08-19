using APPLICATION.Dto.AccessList;
using APPLICATION.Dto.User;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.UserAccess;
public class UserAccessDto
{
    // public int Id { get; set; }

    // Fk User
    public string UserId { get; set; }

    // Fk AccessList
    public int AccessListId { get; set; }

    // FK AccessListAction
    public int AccessListActionId { get; set; }
}
