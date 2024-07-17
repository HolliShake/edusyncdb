using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SkillsFrameworkJobRoleToCriticalWorkFunction;
public class GetSkillsFrameworkJobRoleToCriticalWorkFunctionDto
{
    // Fk SkillsFrameworkJobRole
    public int SfJoBRole { get; set; }

    // Fk SkillsFrameworkCriticalWorkFunction
    public int SfCriticalWorkFunctionId { get; set; }
}
