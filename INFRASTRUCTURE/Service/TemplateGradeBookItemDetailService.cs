
using APPLICATION.Dto.TemplateGradeBookItemDetail;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class TemplateGradeBookItemDetailService:GenericService<TemplateGradeBookItemDetail, GetTemplateGradeBookItemDetailDto>, ITemplateGradeBookItemDetailService
{
    public TemplateGradeBookItemDetailService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
