using AutoMapper;
using APPLICATION.Dto.Bulletin;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class BulletinMapper : Profile
{
    public BulletinMapper()
    {
        CreateMap<BulletinDto, Bulletin>();
        CreateMap<Bulletin, GetBulletinDto>();
    }
}
