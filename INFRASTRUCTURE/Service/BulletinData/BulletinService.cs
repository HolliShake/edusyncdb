using AutoMapper;
using APPLICATION.Dto.Bulletin;
using APPLICATION.IService.BulletinData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service.BulletinData;

public class BulletinService:GenericService<Bulletin, GetBulletinDto>, IBulletinService
{
    public BulletinService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetBulletinDto>> GetBulletinsByBulletinCategoryId(int bulletinCategoryId)
    {
        var bulletins = await _dbModel
        .Where(b => b.BulletinCategoryId == bulletinCategoryId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetBulletinDto>>(bulletins);
    }
}
