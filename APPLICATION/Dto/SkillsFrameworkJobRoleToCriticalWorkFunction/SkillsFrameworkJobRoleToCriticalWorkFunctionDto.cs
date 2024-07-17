using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SkillsFrameworkJobRoleToCriticalWorkFunction;
public class SkillsFrameworkJobRoleToCriticalWorkFunctionDto
{
    // Fk SkillsFrameworkJobRole
    public int SfJoBRole { get; set; }

    // Fk SkillsFrameworkCriticalWorkFunction
    public int SfCriticalWorkFunctionId { get; set; }
}
