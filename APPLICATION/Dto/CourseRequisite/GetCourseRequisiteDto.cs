using APPLICATION.Dto.Course;
using DOMAIN.Model;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.CourseRequisite;
public class GetCourseRequisiteDto
{
    public int Id { get; set; }
    public CourseRequisiteType Type { get; set; }
    // Fk Course
    [Required]
    public int CourseId { get; set; }
    public GetCourseDto Course { get; set; }

    // Fk Course (Requisite)
    [Required]
    public int RequisiteCourseId { get; set; }
    public GetCourseDto RequisiteCourse { get; set; }
}
