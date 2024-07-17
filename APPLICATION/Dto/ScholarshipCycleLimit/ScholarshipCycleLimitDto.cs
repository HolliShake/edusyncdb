using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ScholarshipCycleLimit;
public class ScholarshipCycleLimitDto
{
    public int MaxNumberOfScholars { get; set; }
    public bool IsOpenOverride { get; set; }
    public bool IsEnabled { get; set; }
    public DateTime ApplicationStartDateTime { get; set; }
    public DateTime ApplicationEndDateTime { get; set; }

    // Fk Cycle
    public int CycleId { get; set; }

    // Fk ScholarshipList
    public int ScholarshipListId { get; set; }
}
