
using APPLICATION.Dto.BulletinScope;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class BulletinScopeService:GenericService<BulletinScope, GetBulletinScopeDto>, IBulletinScopeService
{
    public BulletinScopeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetBulletinScopeDto>> GetBulletinScopesByAcademicProgramId(int academicProgramId)
    {
        return _mapper.Map<ICollection<GetBulletinScopeDto>>(await _dbModel
            .Include(bs => bs.Bulletin)
            .Include(bs => bs.AcademicProgramId)
            .Where(bs => bs.AcademicProgramId == academicProgramId)
            .ToListAsync());
    }

    public async Task<ICollection<GetBulletinScopeDto>> GetBulletinScopesByBulletinId(int bulletinId)
    {
        return _mapper.Map<ICollection<GetBulletinScopeDto>>(await _dbModel
            .Include(bs => bs.Bulletin)
            .Include(bs => bs.AcademicProgramId)
            .Where(bs => bs.BulletinId == bulletinId)
            .ToListAsync());
    }
}
