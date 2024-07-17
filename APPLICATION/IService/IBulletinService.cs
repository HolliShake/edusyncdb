
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IBulletinService:IGenericService<Bulletin>
{
    public Task<ICollection<Bulletin>> GetBulletinsByBulletinCategoryId(int bulletinCategoryId);
}
