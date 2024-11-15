
using APPLICATION.Dto.Requirement;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class RequirementService:GenericService<Requirement, GetRequirementDto>, IRequirementService
{
    public RequirementService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetRequirementDto>> GetActiveRequirement()
    {
        var requirements = await _dbModel
        .Where(r => r.IsActive)
        .ToListAsync();
        return _mapper.Map<ICollection<GetRequirementDto>>(requirements);
    }
}
