using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.CourseFee;
public class CourseFeeDto
{
    public int Id { get; set; }
    // Fk Course
    public int CourseId { get; set; }
    // FK Fee
    public int FeeId { get; set; }
}
