using APPLICATION.Dto.SkillsFrameworkJobRoleToCriticalWorkFunction;
using APPLICATION.Dto.SkillsFrameworkProficiencyLevel;
using APPLICATION.Dto.SkillsFrameworkSkills;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SkillsFrameworkJobRoleToProficiencyLevel;
public class GetSkillsFrameworkJobRoleToProficiencyLevelDto
{
    public int Id { get; set; }

    // Fk SkillsFrameworkJobRoleToCriticalWorkFunction
    public int SfJobRoleToCriticalWorkFunctionId { get; set; }
    public GetSkillsFrameworkJobRoleToCriticalWorkFunctionDto SfJobRoleToCriticalWorkFunction { get; set; }

    // Fk SkillsFrameworkSkills
    public int SfSkillsId { get; set; }
    public GetSkillsFrameworkSkillsDto SkillsFrameworkSkills { get; set; }

    // FK SkillsFrameworkProficiencyLevel
    public int SfProficiencyLevelId { get; set; }
    public GetSkillsFrameworkProficiencyLevelDto SfProficiencyLevel { get; set; }
}
