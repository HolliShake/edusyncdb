using APPLICATION.Dto.Course;
using APPLICATION.Dto.SkillsFrameworkSkillsToCompetency;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SkillsFrameworkCourseToCompetency;
public class GetSkillsFrameworkCourseToCompetencyDto
{
    public int Id { get; set; }
    
    // Fk Course
    public int CourseId { get; set; }
    public GetCourseDto Course { get; set; }

    // Fk SkillsToCompetency
    public int SkillsToCompetencyId { get; set; }
    public GetSkillsFrameworkSkillsToCompetencyDto SkillsFrameworkSkillsToCompetency { get; set; }
}
