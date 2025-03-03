using APPLICATION.IService.CoreData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class GraduateAttributesService:GenericService<GraduateAttributes, GetGraduateAttributesDto>, IGraduateAttributesService
{
    public GraduateAttributesService(AppDbContext context):base(context)
    {
    }
}
