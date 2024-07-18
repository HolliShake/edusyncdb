
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
        return _mapper.Map<ICollection<GetAdmissionProgramRequirementDto>>(await _dbModel.Include(apr => apr.Requirement).ToListAsync());
    }

    public new async Task<ICollection<GetAdmissionProgramRequirementDto>> GetByChunk(int max)
    {
        return _mapper.Map<ICollection<GetAdmissionProgramRequirementDto>>(await _dbModel.Include(apr => apr.Requirement).Take(max).ToListAsync());
    }

    public new async Task<AdmissionProgramRequirement?> GetAsync(int id)
    {
        return _mapper.Map<AdmissionProgramRequirement?>(await _dbModel.Include(apr => apr.Requirement).Where(apr => apr.Id == id).FirstOrDefaultAsync());
    }

    public async Task<ICollection<GetAdmissionProgramRequirementDto>> GetEnabledAdmissionProgramRequirements()
    {
        return _mapper.Map<ICollection<GetAdmissionProgramRequirementDto>>(await _dbModel.Include(apr => apr.Requirement).Where(apr => apr.IsEnabled).ToListAsync());
    }
}
