using APPLICATION.Dto.ParameterCategory;

namespace APPLICATION.Dto.Instrument;

public class InstrumentGroupDto:InstrumentDto
{
    public List<ParameterCategoryGroupDto> ParameterCategories { get; set; }
}