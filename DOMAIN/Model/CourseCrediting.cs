using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class CourseCrediting
{
    public int Id { get; set; }
    public string CreditedFromCourseTitle { get; set; }
    public string CreditedFromCourseCode { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal CreditGrades { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal CreditUnits { get; set; }
    public string Remarks { get; set; }
    public DateTime EncodedDateTime { get; set; }
    public DateTime CreditedDateTime { get; set; }

    // Fk User (To Credit)
    public string CreditToUserId { get; set; }
    public User CreditToUser { get; set; }

    // Fk User (Evaluated By)
    public string EvaluatedByUserId { get; set; }
    public User EvaluatedByUser { get; set; }

    // Fk Course
    public int CourseId { get; set; }
    public Course Course { get; set; }
    // Fk OtherSchool
    public int CreditedFromSchoolId { get; set; }
    public OtherSchool OtherSchool { get; set; }
}