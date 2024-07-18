using APPLICATION.Dto.AccessList;
using APPLICATION.Dto.AccessListAction;
using APPLICATION.Dto.User;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.UserAccess;
public class GetUserAccessDto
{
    public int Id { get; set; }

    // Fk User
    public string UserId { get; set; }
    public GetUserOnlyDto User { get; set; }

    // Fk AccessList
    public int AccessListId { get; set; }
    public GetAccessListDto AccessList { get; set; }

    // FK AccessListAction
    public int AccessListActionId { get; set; }
    public GetAccessListActionDto AccessListAction { get; set; }
}
