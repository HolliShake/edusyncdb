using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AdmissionEducationalBackground;
public class AdmissionEducationalBackgroundDto
{
    public string SchoolName { get; set; }
    public AdmissionEducationalBackgroundEduType Type { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    // Fk
    public int ApplicantId { get; set; }
}
