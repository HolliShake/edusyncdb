using APPLICATION.Dto.Campus;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.Cycle;
public class GetCycleDto
{
    public int Id { get; set; }
    public string CycleDescription { get; set; }
    public int CylceNumber { get; set; }
    public string SchoolYear { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    // Fk Campus
    public int CampusId { get; set; }
    public GetCampusDto Campus { get; set; }
}
