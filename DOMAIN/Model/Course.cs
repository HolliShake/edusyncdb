
using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class Course
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

    //
    [ForeignKey("Parent")]
    public int? ParentId { get; set; }
    public Course Parent { get; set; }

    // Fk EducationalQualityAssuranceType
    public int EducationalQualityAssuranceTypeId { get; set; }
    public EducationalQualityAssuranceType EducationalQualityAssuranceType { get; set; }
    
    // Fk SkillsFrameworkTrackSpecialization
    public int SfTrackSpecializationId { get; set; }
    public SkillsFrameworkTrackSpecialization SfTrackSpecialization { get; set; }

    // Nav
    [InverseProperty("Course")]
    public virtual ICollection<CourseRequisite> CourseRequisites { get; set; }
}