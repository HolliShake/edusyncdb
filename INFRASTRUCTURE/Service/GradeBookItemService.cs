using APPLICATION.Dto.GradeBookItem;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class GradeBookItemService:GenericService<GradeBookItem, GetGradeBookItemDto>, IGradeBookItemService
{
    public GradeBookItemService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
