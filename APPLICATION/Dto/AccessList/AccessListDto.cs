using APPLICATION.Dto.AccessListAction;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AccessList;
public class AccessListDto
{
    [Required]
    [MinLength(4)]
    [MaxLength(30)]
    public string Subject { get; set; }
    [Required]
    public bool IsGroup { get; set; }
}
