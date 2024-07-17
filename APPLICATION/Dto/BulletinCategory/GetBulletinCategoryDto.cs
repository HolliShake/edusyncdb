using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.BulletinCategory;
public class GetBulletinCategoryDto
{
    public int Id { get; set; }
    public string Category { get; set; }
}
