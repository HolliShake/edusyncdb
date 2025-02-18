using AutoMapper;
using APPLICATION.Dto.AdmissionEvaluationSchedule;
using APPLICATION.IService.AdmissionData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service.AdmissionData;

public class AdmissionEvaluationScheduleService:GenericService<AdmissionEvaluationSchedule, GetAdmissionEvaluationScheduleDto>, IAdmissionEvaluationScheduleService
{
    public AdmissionEvaluationScheduleService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetAdmissionEvaluationScheduleDto>> GetAdmissionEvaluationSchedulesByAdmissionScheduleId(int admissionSchedueId)
    {
        var admissionEvaluationSchedules = await _dbModel
        .Where(aes => aes.AdmissionScheduleId == admissionSchedueId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetAdmissionEvaluationScheduleDto>>(admissionEvaluationSchedules);
    }
}
