using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPLICATION.Dto.Course;
public class CourseDto
{
    [Required]
    [MinLength(5)]
    [MaxLength(50)]
    public string CourseTitle { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(25)]
    public string CourseCode { get; set; }
    [MaxLength(255)]
    public string CourseDescription { get; set; }
    [Required]
    public bool WithLaboratory { get; set; }
    [Required]
    public bool IsSpecialize { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    [Required]
    public decimal LectureUnits { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    [Required]
    public decimal LaboratoryUnits { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    [Required]
    public decimal CreditUnits { get; set; }

    // Fk EducationalQualityAssuranceType
    [Required]
    public int EducationalQualityAssuranceTypeId { get; set; }

    // Fk SkillsFrameworkTrackSpecialization
    public int SfTrackSpecializationId { get; set; }
}
