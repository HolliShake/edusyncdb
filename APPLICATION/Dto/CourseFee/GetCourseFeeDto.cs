using APPLICATION.Dto.Course;
using APPLICATION.Dto.EnrollmentFee;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.CourseFee;
public class GetCourseFeeDto
{
    public int Id { get; set; }
    // Fk Course
    public int CourseId { get; set; }
    public GetCourseDto Course { get; set; }
    // FK Fee
    public int FeeId { get; set; }
    public GetEnrollmentFeeDto Fee { get; set; }
}
