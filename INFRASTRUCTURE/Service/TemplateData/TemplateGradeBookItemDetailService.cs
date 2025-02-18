using AutoMapper;
using APPLICATION.Dto.TemplateGradeBookItemDetail;
using APPLICATION.IService.TemplateData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.TemplateData;

public class TemplateGradeBookItemDetailService:GenericService<TemplateGradeBookItemDetail, GetTemplateGradeBookItemDetailDto>, ITemplateGradeBookItemDetailService
{
    public TemplateGradeBookItemDetailService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
