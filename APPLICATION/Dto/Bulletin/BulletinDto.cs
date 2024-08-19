using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.Bulletin;
public class BulletinDto
{
    [Required]
    [MinLength(4)]
    [MaxLength(50)]
    public string Title { get; set; }
    [Required]
    [MaxLength(5000)]
    public string Content { get; set; }
    [Required]
    [MinLength(4)]
    [MaxLength(255)]
    public string Infographics { get; set; }
    //
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    public bool IsVisible { get; set; }
    [Required]
    public bool IsEnable { get; set; }
    [Required]
    public int Priority { get; set; }

    // Fk BulletinCategory
    [Required]
    public int BulletinCategoryId { get; set; }

    // Fk User
    [Required]
    public string PostedByUserId { get; set; }
}
