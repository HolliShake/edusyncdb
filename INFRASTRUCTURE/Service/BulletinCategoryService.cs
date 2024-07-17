
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class BulletinCategoryService:GenericService<BulletinCategory>, IBulletinCategoryService
{
    public BulletinCategoryService(AppDbContext context):base(context)
    {
    }
}
