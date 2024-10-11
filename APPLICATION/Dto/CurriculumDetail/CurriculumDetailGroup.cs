namespace APPLICATION.Dto.CurriculumDetail;

public class CurriculumDetailGroup
{
    public int YearLevel { get; set; }
    public int TermNumber { get; set; }
    public bool IsIncludeGWA { get; set; }

    // Fk Curriculum
    public int CurriculumId { get; set; }

    // Fk Course
    public int[] CourseId { get; set; }
}