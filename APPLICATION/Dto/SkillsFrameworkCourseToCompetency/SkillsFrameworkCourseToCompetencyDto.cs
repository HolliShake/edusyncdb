using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SkillsFrameworkCourseToCompetency;
public class SkillsFrameworkCourseToCompetencyDto
{   
    // Fk Course
    public int CourseId { get; set; }

    // Fk SkillsToCompetency
    public int SkillsToCompetencyId { get; set; }
}
