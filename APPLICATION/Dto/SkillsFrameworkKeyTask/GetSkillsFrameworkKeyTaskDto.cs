using APPLICATION.Dto.SkillsFrameworkCriticalWorkFunction;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SkillsFrameworkKeyTask;
public class GetSkillsFrameworkKeyTaskDto
{
    public int Id { get; set; }
    public string KeyTask { get; set; }

    // Fk SkillsFrameworkCriticalWorkFunction
    public int SfCriticalWorkFunctionId { get; set; }
    public GetSkillsFrameworkCriticalWorkFunctionDto SfCriticalWorkFunction { get; set; }
}
