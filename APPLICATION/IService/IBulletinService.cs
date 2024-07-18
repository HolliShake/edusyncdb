
using APPLICATION.Dto.Bulletin;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IBulletinService:IGenericService<Bulletin, GetBulletinDto>
{
    public Task<ICollection<GetBulletinDto>> GetBulletinsByBulletinCategoryId(int bulletinCategoryId);
}
