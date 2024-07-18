using APPLICATION.Dto.GradeBookItem;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IGradeBookItemService:IGenericService<GradeBookItem, GetGradeBookItemDto>
{
}
