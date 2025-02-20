using APPLICATION.Dto.BulletinCategory;
using DOMAIN.Model;

namespace APPLICATION.IService.BulletinData;

public interface IBulletinCategoryService:IGenericService<BulletinCategory, GetBulletinCategoryDto>
{
}
