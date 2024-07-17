namespace DOMAIN.Model;

public class SkillsFrameworkCourseToCompetency
{
    public int Id { get; set; }
    
    // Fk Course
    public int CourseId { get; set; }
    public Course Course { get; set; }

    // Fk SkillsToCompetency
    public int SkillsToCompetencyId { get; set; }
    public SkillsFrameworkSkillsToCompetency SkillsFrameworkSkillsToCompetency { get; set; }
}