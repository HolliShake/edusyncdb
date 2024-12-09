using APPLICATION.Dto.ParameterCategory;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.Instrument;
public class GetInstrumentDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int NumberOfChoices { get; set; }
    public bool IsEnabled { get; set; }
    // Navigation Properties
    public ICollection<GetParameterCategoryDto> ParameterCategories { get; set; }
}
