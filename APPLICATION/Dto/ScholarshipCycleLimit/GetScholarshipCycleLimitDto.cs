using APPLICATION.Dto.Cycle;
using APPLICATION.Dto.ScholarshipList;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ScholarshipCycleLimit;
public class GetScholarshipCycleLimitDto
{
    public int Id { get; set; }

    public int MaxNumberOfScholars { get; set; }
    public bool IsOpenOverride { get; set; }
    public bool IsEnabled { get; set; }
    public DateTime ApplicationStartDateTime { get; set; }
    public DateTime ApplicationEndDateTime { get; set; }

    // Fk Cycle
    public int CycleId { get; set; }
    public GetCycleDto Cycle { get; set; }

    // Fk ScholarshipList
    public int ScholarshipListId { get; set; }
    public GetScholarshipListDto ScholarshipList { get; set; }
}
