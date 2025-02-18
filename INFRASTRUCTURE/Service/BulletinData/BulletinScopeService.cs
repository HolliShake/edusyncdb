using AutoMapper;
using Microsoft.EntityFrameworkCore;
using APPLICATION.Dto.BulletinScope;
using APPLICATION.IService.BulletinData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.BulletinData;

public class BulletinScopeService:GenericService<BulletinScope, GetBulletinScopeDto>, IBulletinScopeService
{
    public BulletinScopeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetBulletinScopeDto>> GetBulletinScopesByAcademicProgramId(int academicProgramId)
    {
        var bulletins = await _dbModel
        .Include(bs => bs.Bulletin) // Correctly include the Bulletin navigation property
        .Where(bs => bs.AcademicProgramId == academicProgramId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetBulletinScopeDto>>(bulletins);
    }

    public async Task<ICollection<GetBulletinScopeDto>> GetBulletinScopesByBulletinId(int bulletinId)
    {
        var bulletins = await _dbModel
        .Include(bs => bs.Bulletin)
        .Where(bs => bs.BulletinId == bulletinId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetBulletinScopeDto>>(bulletins);
    }
}
