using DOMAIN.Model;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.CourseRequisite;
public class CourseRequisiteDto
{
    public CourseRequisiteType Type { get; set; }
    // Fk Course
    [Required]
    public int CourseId { get; set; }

    // Fk Course (Requisite)
    [Required]
    public int RequisiteCourseId { get; set; }
}
