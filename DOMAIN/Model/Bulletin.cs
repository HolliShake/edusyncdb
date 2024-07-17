using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class Bulletin
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
    public BulletinCategory Category { get; set; }

    // Fk User
    [ForeignKey("PostedByUser")]
    public string PostedByUserId { get; set; }
    public User PostedByUser { get; set; }
}