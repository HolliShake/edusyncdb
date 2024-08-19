using APPLICATION.Dto.AccessListAction;
using DOMAIN.Model;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AccessList;
public class GetAccessListDto
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public bool IsGroup { get; set; }
    public AccessListType Type { get; set; }

    // Fk AccessList
    public int? ParentId { get; set; }
    public GetAccessListDto Parent { get; set; }

    // Nav
    public virtual ICollection<GetAccessListActionDto> AccessListActions { get; set; }
    // Nav
    public virtual ICollection<GetAccessListDto> Children { get; set; }
}
