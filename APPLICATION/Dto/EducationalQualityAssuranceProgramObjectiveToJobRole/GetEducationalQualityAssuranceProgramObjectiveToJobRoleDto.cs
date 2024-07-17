using APPLICATION.Dto.EducationalQualityAssuranceProgramObjective;
using APPLICATION.Dto.SkillsFrameworkJobRole;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EducationalQualityAssuranceProgramObjectiveToJobRole;
public class GetEducationalQualityAssuranceProgramObjectiveToJobRoleDto
{
    public int Id { get; set; }

    // Fk EducationalQualityAssuranceProgramObjective
    public int EqaProgramObjectiveId { get; set; }
    public GetEducationalQualityAssuranceProgramObjectiveDto EqaProgramObjective { get; set; }

    // Fk SkillsFrameworkJobRole
    public int SfJobRoleId { get; set; }
    public GetSkillsFrameworkJobRoleDto SfJobRole { get; set; }
}
