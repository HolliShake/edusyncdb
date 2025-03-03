using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.GraduateAttributes;
public class GetGraduateAttributesDto
{
    public int Id { get; set; }

    public string AttributeCode { get; set; }

    public string AttributeDesc { get; set; }

    public int SortOrder { get; set; }

    public bool IsEnabled { get; set; }
}
