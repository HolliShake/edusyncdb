using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class PetitionCourses
{
    public int Id { get; set; }
    public DateTime PetitionDateTime { get; set; }
    public string ReasonText { get; set; }

    // Fk User
    [ForeignKey("PetitionByUser")]
    public string PetitionByUserId { get; set; }
    public User PetitionByUser { get; set; }

    // Fk AcademicProgram
    public int AcademicProgramId { get; set; }
    public AcademicProgram AcademicProgram { get; set; }

    // Fk Course
    public int CourseId { get; set; }
    public Course Course { get; set; }

    // Fk Cycle
    public int CycleId { get; set; }
    public Cycle Cycle { get; set; }
}