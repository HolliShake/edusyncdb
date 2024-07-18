
using APPLICATION.Dto.AdmissionEvaluationSchedule;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class AdmissionEvaluationScheduleService:GenericService<AdmissionEvaluationSchedule, GetAdmissionEvaluationScheduleDto>, IAdmissionEvaluationScheduleService
{
    public AdmissionEvaluationScheduleService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetAdmissionEvaluationScheduleDto>> GetAdmissionEvaluationSchedulesByAdmissionScheduleId(int admissionSchedueId)
    {
        return _mapper.Map<ICollection<GetAdmissionEvaluationScheduleDto>>(await _dbModel.Where(aes => aes.AdmissionScheduleId == admissionSchedueId).ToListAsync());
    }
}
