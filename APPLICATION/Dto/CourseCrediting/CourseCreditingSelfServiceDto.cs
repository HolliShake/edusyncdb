using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.CourseCrediting;
public class CourseCreditingSelfServiceDto
{
    [Required]
    public string CreditedFromCourseTitle { get; set; }
    [Required]
    public string CreditedFromCourseCode { get; set; }
    [Required]
    public decimal CreditGrades { get; set; }
    [Required]
    public decimal CreditUnits { get; set; }

    /*
    public string Remarks { get; set; }
    public DateTime EncodedDateTime { get; set; }
    public DateTime CreditedDateTime { get; set; }

    // public GlobalValidityStatusEnum Status { get; set; }

    // Fk User (To Credit)
    public string CreditToUserId { get; set; }

    // Fk User (Evaluated By)
    public string EvaluatedByUserId { get; set; }
    */

    // Fk Course
    [Required]
    public int CourseId { get; set; }

    // Fk OtherSchool
    [Required]
    public int CreditedFromSchoolId { get; set; }
}