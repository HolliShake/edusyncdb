
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IBulletinScopeService:IGenericService<BulletinScope>
{
    public Task<ICollection<BulletinScope>> GetBulletinScopesByAcademicProgramId(int academicProgramId);
    public Task<ICollection<BulletinScope>> GetBulletinScopesByBulletinId(int bulletinId);
}
