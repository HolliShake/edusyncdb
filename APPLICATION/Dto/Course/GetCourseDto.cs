using APPLICATION.Dto.CourseRequisite;
using APPLICATION.Dto.EducationalQualityAssuranceType;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPLICATION.Dto.Course;
public class GetCourseDto
{
    public int Id { get; set; }
    public string CourseTitle { get; set; }
    public string CourseCode { get; set; }
    public string CourseDescription { get; set; }
    public bool WithLaboratory { get; set; }
    public bool IsSpecialize { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal LectureUnits { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal LaboratoryUnits { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal CreditUnits { get; set; }

    // Fk EducationalQualityAssuranceType
    public int EducationalQualityAssuranceTypeId { get; set; }
    public GetEducationalQualityAssuranceTypeDto EducationalQualityAssuranceType { get; set; }

    // Nav
    public ICollection<GetCourseRequisiteDto> CourseRequisites { get; set; }
}
