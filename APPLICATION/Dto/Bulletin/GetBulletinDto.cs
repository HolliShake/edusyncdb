using APPLICATION.Dto.BulletinCategory;
using APPLICATION.Dto.User;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.Bulletin;
public class GetBulletinDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Infographics { get; set; }
    //
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsVisible { get; set; }
    public bool IsEnable { get; set; }
    public int Priority { get; set; }

    // Fk BulletinCategory
    public int BulletinCategoryId { get; set; }
    public GetBulletinCategoryDto Category { get; set; }

    // Fk User
    public string PostedByUserId { get; set; }
    public GetUserOnlyDto PostedByUser { get; set; }
}
