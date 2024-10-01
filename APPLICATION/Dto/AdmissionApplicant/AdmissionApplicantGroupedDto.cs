using APPLICATION.Dto.AdmissionApplicantFamilyDetails;
using APPLICATION.Dto.AdmissionEducationalBackground;

namespace APPLICATION.Dto.AdmissionApplicant;

public class AdmissionApplicantGroupedDto:AdmissionApplicantDto
{
    public AdmissionFatherDto Father { get; set; }
    public AdmissionMotherDto Mother { get; set; }
    public AdmissionFatherDto Guardian { get; set; }
    public AdmissionSiblingDto[] Siblings { get; set; }
    public string[] Sports { get; set; }
    public string[] Arts { get; set; }
    public string[] Techhnical { get; set; }
        
    public AdmissionEducationalBackgroundGenerateDto[] EducationalBackground { get; set; }
}