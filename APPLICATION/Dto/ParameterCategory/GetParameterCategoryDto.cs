using APPLICATION.Dto.Instrument;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ParameterCategory;
public class GetParameterCategoryDto
{
    public int Id { get; set; }
    public string ParameterCategoryName { get; set; }

    // Fk Instrument
    public int InstrumentId { get; set; }
    public GetInstrumentDto Instrument { get; set; }
}
