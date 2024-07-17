
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class AdmissionScoreService:GenericService<AdmissionScore>, IAdmissionScoreService
{
    public AdmissionScoreService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<AdmissionScore>> GetAdmissionScoreByAdmissionEvaluationScheduleId(int admissionEvaluationScheduleId)
    {
        return await _dbModel
            .Include(ads => ads.AdmissionEvaluationSchedule)
            .Where(ads => ads.AdmissionEvaluationScheduleId == admissionEvaluationScheduleId)
            .ToListAsync();
    }

    public async Task<ICollection<AdmissionScore>> GetAdmissionScoreByAdmissionProgramRequirementId(int admissionProgramRequirementId)
    {
        return await _dbModel
            .Include(ads => ads.AdmissionProgramRequirement)
            .Where(ads => ads.AdmissionProgramRequirementId == admissionProgramRequirementId)
            .ToListAsync();
    }

    public async Task<ICollection<AdmissionScore>> GetAdmissionScoreByAdmissionApplicantId(int admissionApplicantId)
    {
        return await _dbModel
           .Include(ads => ads.AdmissionApplicant)
           .Where(ads => ads.AdmissionApplicantId == admissionApplicantId)
           .ToListAsync();
    }
}
