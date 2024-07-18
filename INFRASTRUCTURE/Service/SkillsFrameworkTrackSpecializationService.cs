
using APPLICATION.Dto.SkillsFrameworkTrackSpecialization;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkTrackSpecializationService:GenericService<SkillsFrameworkTrackSpecialization, GetSkillsFrameworkTrackSpecializationDto>, ISkillsFrameworkTrackSpecializationService
{
    public SkillsFrameworkTrackSpecializationService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetSkillsFrameworkTrackSpecializationDto>> GetSkillsFrameworkTrackSpecializationsBySectorDisciplineId(int sectorDisciplineId)
    {
        return _mapper.Map<ICollection<GetSkillsFrameworkTrackSpecializationDto>>(await _dbModel
            .Include(sfts => sfts.SectorDiscipline)
            .Where(sfts => sfts.SectorDisciplineId == sectorDisciplineId)
            .ToListAsync());
    }
}
