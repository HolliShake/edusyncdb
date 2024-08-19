using APPLICATION.Dto.AccessListAction;
using DOMAIN.Model;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AccessList;
public class AccessListDto
{
    [Required]
    [MinLength(2)]
    [MaxLength(30)]
    public string Subject { get; set; }

    [Required]
    public bool IsGroup { get; set; }

    [Required]
    public AccessListType Type { get; set; }

    // Fk AccessList
    public int? ParentId { get; set; }
}
