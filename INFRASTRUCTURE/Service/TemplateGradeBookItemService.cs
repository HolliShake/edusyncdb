
using APPLICATION.Dto.TemplateGradeBookItem;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class TemplateGradeBookItemService:GenericService<TemplateGradeBookItem, GetTemplateGradeBookItemDto>, ITemplateGradeBookItemService
{
    public TemplateGradeBookItemService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
