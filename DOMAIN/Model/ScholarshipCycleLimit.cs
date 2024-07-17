namespace DOMAIN.Model;

public class ScholarshipCycleLimit
{
    public int Id { get; set; }

    public int MaxNumberOfScholars { get; set; }
    public bool IsOpenOverride { get; set; }
    public bool IsEnabled { get; set; }
    public DateTime ApplicationStartDateTime { get; set; }
    public DateTime ApplicationEndDateTime { get; set; }

    // Fk Cycle
    public int CycleId { get; set; }
    public Cycle Cycle { get; set; }

    // Fk ScholarshipList
    public int ScholarshipListId { get; set; }
    public ScholarshipList ScholarshipList { get; set; }
}