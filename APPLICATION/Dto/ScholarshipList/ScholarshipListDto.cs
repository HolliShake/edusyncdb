using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ScholarshipList;
public class ScholarshipListDto
{
    public string ScholarshipName { get; set; }
    public string ShortName { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public string Sponsor { get; set; }
    public string Status { get; set; }
    public bool IsEnabled { get; set; }
}
