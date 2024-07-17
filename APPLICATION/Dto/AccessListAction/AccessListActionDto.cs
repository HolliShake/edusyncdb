using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AccessListAction;
public class AccessListActionDto
{
    [Required]
    [MinLength(3)]
    [MaxLength(25)]
    public string Action { get; set; }

    // Fk AccessList
    [Required]
    public int AccessListId { get; set; }
}
