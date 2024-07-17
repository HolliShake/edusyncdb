using AutoMapper;
using APPLICATION.Dto.BulletinScope;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class BulletinScopeMapper : Profile
{
    public BulletinScopeMapper()
    {
        CreateMap<BulletinScopeDto, BulletinScope>();
        CreateMap<BulletinScope, GetBulletinScopeDto>();
    }
}
