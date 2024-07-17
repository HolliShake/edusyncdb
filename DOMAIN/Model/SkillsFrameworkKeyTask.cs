namespace DOMAIN.Model;

public class SkillsFrameworkKeyTask
{
    public int Id { get; set; }
    public string KeyTask { get; set; }

    // Fk SkillsFrameworkCriticalWorkFunction
    public int SfCriticalWorkFunctionId { get; set; }
    public SkillsFrameworkCriticalWorkFunction SfCriticalWorkFunction { get; set; }
}