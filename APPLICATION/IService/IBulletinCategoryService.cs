using APPLICATION.Dto.BulletinCategory;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IBulletinCategoryService:IGenericService<BulletinCategory, GetBulletinCategoryDto>
{
}
