namespace DOMAIN.Model;

public class TemplateGradeBook
{
    public int Id { get; set; }
    public string TemplateName { get; set; }
    // Nav
    public ICollection<TemplateGradeBookItem> TemplateGradeBookItems { get; set; }
}