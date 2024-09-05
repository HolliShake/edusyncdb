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
    // Fk AccessGroup
    public int AccessGroupId { get; set; }
}
