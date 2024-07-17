using APPLICATION.Dto.AdmissionSchedule;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AdmissionEvaluationSchedule;
public class GetAdmissionEvaluationScheduleDto
{
    public int Id { get; set; }
    public string EvaluationScheduleDescription { get; set; }
    public DateTime EvaluationScheduleStart { get; set; }
    public DateTime EvaluationScheduleEnd { get; set; }
    public bool IsOnlineMode { get; set; }
    public string EvaluationOnlineLink { get; set; } // If IsOnlineMode
    public string EvaluationOnlinePassword { get; set; } // If IsOnlineMode
    public string EvaluationLocation { get; set; } // If face to face

    // Fk AdmissionSchedule 
    public int AdmissionScheduleId { get; set; }
    public GetAdmissionScheduleDto AdmissionSchedule { get; set; }
}
