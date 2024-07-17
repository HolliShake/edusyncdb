namespace DOMAIN.Model;
public class CurriculumDetail
{
    public int Id { get; set; }
    public int YearLevel { get; set; }
    public int TermNumber { get; set; }
    public bool IsIncludeGWA { get; set; }
    // Fk Curriculum
    public int CurriculumId { get; set; }
    public Curriculum Curriculum { get; set; }
    
    // Fk Course
    public int CourseId { get; set; }
    public Course Course { get; set; }
}