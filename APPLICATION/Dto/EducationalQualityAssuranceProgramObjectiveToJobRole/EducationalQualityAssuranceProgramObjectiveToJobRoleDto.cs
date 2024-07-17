using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EducationalQualityAssuranceProgramObjectiveToJobRole;
public class EducationalQualityAssuranceProgramObjectiveToJobRoleDto
{

    // Fk EducationalQualityAssuranceProgramObjective
    public int EqaProgramObjectiveId { get; set; }

    // Fk SkillsFrameworkJobRole
    public int SfJobRoleId { get; set; }
}
