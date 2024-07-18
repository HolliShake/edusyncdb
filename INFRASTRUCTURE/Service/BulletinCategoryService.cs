using APPLICATION.Dto.BulletinCategory;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class BulletinCategoryService:GenericService<BulletinCategory, GetBulletinCategoryDto>, IBulletinCategoryService
{
    public BulletinCategoryService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
