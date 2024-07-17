using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.PetitionCourses;
public class PetitionCoursesDto
{
    public DateTime PetitionDateTime { get; set; }
    public string ReasonText { get; set; }

    // Fk User
    public string PetitionByUserId { get; set; }

    // Fk AcademicProgram
    public int AcademicProgramId { get; set; }

    // Fk Course
    public int CourseId { get; set; }

    // Fk Cycle
    public int CycleId { get; set; }
}
