using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SkillsFrameworkKeyTask;
public class SkillsFrameworkKeyTaskDto
{
    public string KeyTask { get; set; }

    // Fk SkillsFrameworkCriticalWorkFunction
    public int SfCriticalWorkFunctionId { get; set; }
}
