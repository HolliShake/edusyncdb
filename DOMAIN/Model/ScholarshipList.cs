using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class ScholarshipList
{
    public int Id { get; set; }
    public string ScholarshipName { get; set; }
    public string ShortName { get; set; }
    public string Description { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal Amount { get; set; }
    public string Sponsor { get; set; }
    public string Status { get; set; }
    public bool IsEnabled { get; set; }
}