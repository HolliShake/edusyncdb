using APPLICATION.Dto.Bulletin;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class BulletinService:GenericService<Bulletin, GetBulletinDto>, IBulletinService
{
    public BulletinService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetBulletinDto>> GetBulletinsByBulletinCategoryId(int bulletinCategoryId)
    {
        return _mapper.Map<ICollection<GetBulletinDto>>(await _dbModel.Where(b => b.BulletinCategoryId == bulletinCategoryId).ToListAsync());
    }
}
