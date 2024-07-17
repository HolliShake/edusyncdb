using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.BulletinCategory;
public class BulletinCategoryDto
{
    [Required]
    [MinLength(4)]
    [MaxLength(50)]
    public string Category { get; set; }
}
