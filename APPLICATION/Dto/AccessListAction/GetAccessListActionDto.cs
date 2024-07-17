using APPLICATION.Dto.AccessList;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AccessListAction;
public class GetAccessListActionDto
{
    public int Id { get; set; }
    public string Action { get; set; }

    // Fk AccessList
    public int AccessListId { get; set; }
    public GetAccessListDto AccessList { get; set; }
}
