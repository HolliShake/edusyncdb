namespace APPLICATION.Dto.AdmissionEducationalBackground;

public class AdmissionEducationalBackgroundGenerateDto
{
    public string SchoolName { get; set; }
    public AdmissionEducationalBackgroundEduType Type { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
}