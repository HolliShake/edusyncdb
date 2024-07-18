
using APPLICATION.Dto.BulletinScope;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IBulletinScopeService:IGenericService<BulletinScope, GetBulletinScopeDto>
{
    public Task<ICollection<GetBulletinScopeDto>> GetBulletinScopesByAcademicProgramId(int academicProgramId);
    public Task<ICollection<GetBulletinScopeDto>> GetBulletinScopesByBulletinId(int bulletinId);
}
