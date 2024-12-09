using APPLICATION.Dto.Instrument;
using APPLICATION.Dto.ParameterSubCategory;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ParameterCategory;
public class GetParameterCategoryDto
{
    public int Id { get; set; }
    public string ParameterCategoryName { get; set; }

    // Fk Instrument
    public int InstrumentId { get; set; }
    public GetInstrumentDto Instrument { get; set; }
    // Navigation Properties
    public ICollection<GetParameterSubCategoryDto> ParameterSubCategories { get; set; }
}
