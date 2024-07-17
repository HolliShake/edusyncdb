using AutoMapper;
using APPLICATION.Dto.BulletinCategory;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class BulletinCategoryMapper : Profile
{
    public BulletinCategoryMapper()
    {
        CreateMap<BulletinCategoryDto, BulletinCategory>();
        CreateMap<BulletinCategory, GetBulletinCategoryDto>();
    }
}
