namespace DOMAIN.Model;

public class GeneratedSections
{
    public int Id { get; set; }
    public string SectionName { get; set; }
    public string SectionCode { get; set; }
    // Fk
    public int CycleId { get; set; }
    public Cycle Cycle { get; set; }
    // Fk
    public int CurriculumDetailId { get; set; }
    public CurriculumDetail CurriculumDetail { get; set; }
}
