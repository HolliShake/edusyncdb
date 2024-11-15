using APPLICATION.Dto.AcademicProgram;
using APPLICATION.Dto.Course;
using APPLICATION.Dto.CurriculumDetail;
using APPLICATION.Dto.Cycle;
using APPLICATION.Dto.Room;

namespace APPLICATION.Dto.Schedule;
public class GetScheduleDto
{
    public int Id { get; set; }
    public String GeneratedReference { get; set; }
    public String GeneratedSection { get; set; }

    public int MinStudent { get; set; }
    public int MaxStudent { get; set; }
    public bool IsPetitionSchedule { get; set; }
    public bool IsExclusive { get; set; }

    // Fk Cycle 
    public int? CycleId { get; set; }
    public GetCycleDto Cycle { get; set; }

    // Fk Course
    public int CurriculumDetailId { get; set; }
    public GetCurriculumDetailDto CurriculumDetail { get; set; }

    // Fk User
    public string CreatedByUserId { get; set; }
    public DOMAIN.Model.User CreatedByUser { get; set; }
}
