
using APPLICATION.Dto.AdmissionProgramRequirement;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class AdmissionProgramRequirementService:GenericService<AdmissionProgramRequirement, GetAdmissionProgramRequirementDto>, IAdmissionProgramRequirementService
{
    public AdmissionProgramRequirementService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public new async Task<ICollection<GetAdmissionProgramRequirementDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetAdmissionProgramRequirementDto>>(await _dbModel
            .Include(apr => apr.AdmissionSchedule)
                .ThenInclude(admissionSchedule => admissionSchedule.AcademicProgram)
            .Include(apr => apr.AdmissionSchedule)
                .ThenInclude(admissionSchedule => admissionSchedule.Cycle)
            .Include(apr => apr.Requirement).ToListAsync());
    }

    public async Task<object> GetAllGroupedByRequirementAsync()
    {
        var items = await _dbModel
            .Include(apr => apr.AdmissionSchedule)
                .ThenInclude(admissionSchedule => admissionSchedule.AcademicProgram)
            .Include(apr => apr.AdmissionSchedule)
                .ThenInclude(admissionSchedule => admissionSchedule.Cycle)
            .Include(apr => apr.Requirement)
            .ToListAsync();

        return items
            .GroupBy(apr => apr.AdmissionSchedule);
    }

    public new async Task<ICollection<GetAdmissionProgramRequirementDto>> GetByChunk(int max)
    {
        return _mapper.Map<ICollection<GetAdmissionProgramRequirementDto>>(await _dbModel.Include(apr => apr.Requirement).Take(max).ToListAsync());
    }

    public new async Task<AdmissionProgramRequirement?> GetAsync(int id)
    {
        return _mapper.Map<AdmissionProgramRequirement?>(await _dbModel
            .Include(apr => apr.AdmissionSchedule)
                .ThenInclude(admissionSchedule => admissionSchedule.AcademicProgram)
            .Include(apr => apr.AdmissionSchedule)
                .ThenInclude(admissionSchedule => admissionSchedule.Cycle)
            .Include(apr => apr.Requirement)
            .Where(apr => apr.Id == id).FirstOrDefaultAsync());
    }

    public async Task<ICollection<GetAdmissionProgramRequirementDto>> GetEnabledAdmissionProgramRequirements()
    {
        return _mapper.Map<ICollection<GetAdmissionProgramRequirementDto>>(await _dbModel
            .Include(apr => apr.AdmissionSchedule)
                .ThenInclude(admissionSchedule => admissionSchedule.AcademicProgram)
            .Include(apr => apr.AdmissionSchedule)
                .ThenInclude(admissionSchedule => admissionSchedule.Cycle)
            .Include(apr => apr.Requirement)
            .Where(apr => apr.IsEnabled)
            .ToListAsync());
    }

    public async new Task<bool> CreateAllAsync(IList<AdmissionProgramRequirement> newItems)
    {
        await _dbModel.AddRangeAsync(newItems);
        var result = await Save();
        if (result)
        {
            foreach (var newItem in newItems)
            {
                newItem.Requirement = _dbContext.Requirements.Find(newItem.RequirementId);
                newItem.AdmissionSchedule = _dbContext.AdmissionSchedules.Find(newItem.AdmissionScheduleId);
            }
        }
        return result;
    }

    public async Task<object?> CreateMultipleAdmissionProgramRequirement(AdmissionProgramRequirementMultipleDto item)
    {
        List<AdmissionProgramRequirement> newAdmissionProgramRequirements = [];
        foreach (var requirementId in item.RequirementIds)
        {
            newAdmissionProgramRequirements.Add(new AdmissionProgramRequirement
            {
                AdmissionScheduleId = item.AdmissionScheduleId,
                RequirementId = requirementId,
                IsEnabled = item.IsEnabled,
                PassingScore = item.PassingScore,
            });
        }
        if (newAdmissionProgramRequirements.Count <= 0)
        {
            return null;
        }
        var result = await CreateAllAsync(newAdmissionProgramRequirements);
        if (result)
        {
            foreach (var apr in newAdmissionProgramRequirements)
            {
                apr.AdmissionSchedule = _dbContext.AdmissionSchedules
                        .Include(apr => apr.AcademicProgram)
                        .Include(apr => apr.Cycle)
                        .Where(apr0 => apr0.Id == apr.AdmissionScheduleId)
                        .FirstOrDefault();

                apr.Requirement = _dbContext.Requirements
                    .Where(apr0 => apr0.Id == apr.RequirementId)
                    .FirstOrDefault();
            }
        }
        return (result)
            ? (newAdmissionProgramRequirements)
            : null;
        
    }
}
