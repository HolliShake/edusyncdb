using AutoMapper;
using APPLICATION.Dto.BulletinCategory;
using APPLICATION.IService.BulletinData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.BulletinData;

public class BulletinCategoryService:GenericService<BulletinCategory, GetBulletinCategoryDto>, IBulletinCategoryService
{
    public BulletinCategoryService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
