using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class GraduateAttributes
{
    public int Id { get; set; }

    public string AttributeCode { get; set; }

    public string AttributeDesc { get; set; }

    public int SortOrder { get; set; }

    public bool IsEnabled { get; set; }
}