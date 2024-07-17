using APPLICATION.Dto.Course;
using APPLICATION.Dto.Curriculum;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.CurriculumDetail;
public class GetCurriculumDetailDto
{
    public int Id { get; set; }
    public int YearLevel { get; set; }
    public int TermNumber { get; set; }
    public bool IsIncludeGWA { get; set; }
    // Fk Curriculum
    public int CurriculumId { get; set; }
    public GetCurriculumDto Curriculum { get; set; }
    
    // Fk Course
    public int CourseId { get; set; }
    public GetCourseDto Course { get; set; }
}
