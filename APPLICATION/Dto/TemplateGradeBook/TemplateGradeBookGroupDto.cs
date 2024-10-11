

using APPLICATION.Dto.TemplateGradeBookItem;

namespace APPLICATION.Dto.TemplateGradeBook;
public class TemplateGradeBookGroupDto:TemplateGradeBookDto
{
    public TemplateGradeBookItemGroupDto[] TemplateGradeBookItems { get; set; }
}