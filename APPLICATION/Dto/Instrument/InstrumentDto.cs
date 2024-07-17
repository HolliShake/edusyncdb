using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.Instrument;
public class InstrumentDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int NumberOfChoices { get; set; }
    public bool IsEnabled { get; set; }
}
