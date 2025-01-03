namespace APPLICATION.Dto.CourseCrediting;

public class CourseCreditingDto
{
    public string CreditedFromCourseTitle { get; set; }
    public string CreditedFromCourseCode { get; set; }
    public decimal CreditGrades { get; set; }
    public decimal CreditUnits { get; set; }
    public string Remarks { get; set; }
    public DateTime EncodedDateTime { get; set; }
    public DateTime? CreditedDateTime { get; set; }

    // public GlobalValidityStatusEnum Status { get; set; }

    // Fk User (To Credit)
    public string CreditToUserId { get; set; }

    // Fk User (Evaluated By)
    public string? EvaluatedByUserId { get; set; }

    // Fk Course
    public int CourseId { get; set; }

    // Fk OtherSchool
    public int CreditedFromSchoolId { get; set; }
}
