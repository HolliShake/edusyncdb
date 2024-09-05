using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.TableObject;
public class TableObjectDto
{
    [Required]
    [MinLength(4)]
    [MaxLength(70)]
    public string Uacs { get; set; }
    [Required]
    [MinLength(4)]
    [MaxLength(50)]
    public string AccountName { get; set; }
    // Fk Object
    public int? ParentId { get; set; }

    // Fk AccountGroup
    [Required]
    public int AccountGroupId { get; set; }
}
