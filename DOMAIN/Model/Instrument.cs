namespace DOMAIN.Model;

public class Instrument
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int NumberOfChoices { get; set; }
    public bool IsEnabled { get; set; }
}