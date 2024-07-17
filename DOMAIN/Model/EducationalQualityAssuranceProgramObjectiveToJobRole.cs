namespace DOMAIN.Model;

public class EducationalQualityAssuranceProgramObjectiveToJobRole
{
    public int Id { get; set; }

    // Fk EducationalQualityAssuranceProgramObjective
    public int EqaProgramObjectiveId { get; set; }
    public EducationalQualityAssuranceProgramObjective EqaProgramObjective { get; set; }

    // Fk SkillsFrameworkJobRole
    public int SfJobRoleId { get; set; }
    public SkillsFrameworkJobRole SfJobRole { get; set; }
}