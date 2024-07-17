using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SkillsFrameworkCompetency;
public class SkillsFrameworkCompetencyDto
{
    public string Competency { get; set; }
    public bool IsMicroCredential { get; set; }
    public string CredentialCode { get; set; }
}
