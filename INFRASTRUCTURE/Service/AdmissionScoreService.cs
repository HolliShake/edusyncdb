
using APPLICATION.Dto.AdmissionScore;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class AdmissionScoreService:GenericService<AdmissionScore, GetAdmissionScoreDto>, IAdmissionScoreService
{
    public AdmissionScoreService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetAdmissionScoreDto>> GetAdmissionScoreByAdmissionEvaluationScheduleId(int admissionEvaluationScheduleId)
    {
        return _mapper.Map<ICollection<GetAdmissionScoreDto>>(await _dbModel
            .Include(ads => ads.AdmissionEvaluationSchedule)
            .Where(ads => ads.AdmissionEvaluationScheduleId == admissionEvaluationScheduleId)
            .ToListAsync());
    }

    public async Task<ICollection<GetAdmissionScoreDto>> GetAdmissionScoreByAdmissionProgramRequirementId(int admissionProgramRequirementId)
    {
        return _mapper.Map<ICollection<GetAdmissionScoreDto>>(await _dbModel
            .Include(ads => ads.AdmissionProgramRequirement)
            .Where(ads => ads.AdmissionProgramRequirementId == admissionProgramRequirementId)
            .ToListAsync());
    }

    public async Task<ICollection<GetAdmissionScoreDto>> GetAdmissionScoreByAdmissionApplicantId(int admissionApplicantId)
    {
        return _mapper.Map<ICollection<GetAdmissionScoreDto>>(await _dbModel
           .Include(ads => ads.AdmissionApplicant)
           .Where(ads => ads.AdmissionApplicantId == admissionApplicantId)
           .ToListAsync());
    }
}
