using APPLICATION.Dto.Course;
using APPLICATION.Dto.OtherSchool;
using APPLICATION.Dto.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPLICATION.Dto.CourseCrediting;
public class GetCourseCreditingDto
{
    public int Id { get; set; }
    public string CreditedFromCourseTitle { get; set; }
    public string CreditedFromCourseCode { get; set; }
    public decimal CreditGrades { get; set; }
    public decimal CreditUnits { get; set; }
    public string Remarks { get; set; }
    public DateTime EncodedDateTime { get; set; }
    public DateTime CreditedDateTime { get; set; }

    // Fk User (To Credit)
    public string CreditToUserId { get; set; }
    public GetUserOnlyDto CreditToUser { get; set; }

    // Fk User (Evaluated By)
    public string EvaluatedByUserId { get; set; }
    public GetUserOnlyDto EvaluatedByUser { get; set; }

    // Fk Course
    public int CourseId { get; set; }
    public GetCourseDto Course { get; set; }
    // Fk OtherSchool
    public int CreditedFromSchoolId { get; set; }
    public GetOtherSchoolDto OtherSchool { get; set; }
}
