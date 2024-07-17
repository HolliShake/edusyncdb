namespace DOMAIN.Model;

public class ParameterCategory
{
    public int Id { get; set; }
    public string ParameterCategoryName { get; set; }

    // Fk Instrument
    public int InstrumentId { get; set; }
    public Instrument Instrument { get; set; }
}