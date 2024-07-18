using APPLICATION.Dto.GradeBookItemDetail;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class GradeBookItemDetailService:GenericService<GradeBookItemDetail, GetGradeBookItemDetailDto>, IGradeBookItemDetailService
{
    public GradeBookItemDetailService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
