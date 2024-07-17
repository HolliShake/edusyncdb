using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class CourseRequisite
{
    public int Id { get; set; }
    public CourseRequisiteType Type { get; set; }
    // Fk Course
    [ForeignKey("Course")]
    public int CourseId { get; set; }
    public Course Course { get; set; }

    // Fk Course (Requisite)
    [ForeignKey("RequisiteCourse")]
    public int RequisiteCourseId { get; set; }
    public virtual Course RequisiteCourse { get; set; }
}