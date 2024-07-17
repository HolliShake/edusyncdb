using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ParameterCategory;
public class ParameterCategoryDto
{
    public string ParameterCategoryName { get; set; }

    // Fk Instrument
    public int InstrumentId { get; set; }
}
