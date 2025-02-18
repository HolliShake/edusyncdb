using AutoMapper;
using APPLICATION.Dto.TemplateGradeBookItem;
using APPLICATION.IService.TemplateData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.TemplateData;

public class TemplateGradeBookItemService:GenericService<TemplateGradeBookItem, GetTemplateGradeBookItemDto>, ITemplateGradeBookItemService
{
    public TemplateGradeBookItemService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
