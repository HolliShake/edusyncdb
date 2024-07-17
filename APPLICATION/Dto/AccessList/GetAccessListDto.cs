using APPLICATION.Dto.AccessListAction;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AccessList;
public class GetAccessListDto
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public bool IsGroup { get; set; }
    // Nav
    public virtual ICollection<GetAccessListActionDto> AccessListActions { get; set; }
}
