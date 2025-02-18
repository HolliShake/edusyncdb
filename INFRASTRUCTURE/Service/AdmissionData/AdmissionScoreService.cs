using AutoMapper;
using APPLICATION.Dto.AdmissionScore;
using APPLICATION.IService.AdmissionData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service.AdmissionData;

public class AdmissionScoreService:GenericService<AdmissionScore, GetAdmissionScoreDto>, IAdmissionScoreService
{
    public AdmissionScoreService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetAdmissionScoreDto>> GetAdmissionScoreByAdmissionEvaluationScheduleId(int admissionEvaluationScheduleId)
    {
        var admissionScores = await _dbModel
        .Include(ads => ads.AdmissionEvaluationSchedule)
        .Where(ads => ads.AdmissionEvaluationScheduleId == admissionEvaluationScheduleId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetAdmissionScoreDto>>(admissionScores);
    }

    public async Task<ICollection<GetAdmissionScoreDto>> GetAdmissionScoreByAdmissionProgramRequirementId(int admissionProgramRequirementId)
    {
        var admissionScores = await _dbModel
        .Include(ads => ads.AdmissionProgramRequirement)
        .Where(ads => ads.AdmissionProgramRequirementId == admissionProgramRequirementId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetAdmissionScoreDto>>(admissionScores);
    }

    public async Task<ICollection<GetAdmissionScoreDto>> GetAdmissionScoreByAdmissionApplicantId(int admissionApplicantId)
    {
        var admissionScores = await _dbModel
        .Include(ads => ads.AdmissionApplicant)
        .Where(ads => ads.AdmissionApplicantId == admissionApplicantId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetAdmissionScoreDto>>(admissionScores);
    }
}
