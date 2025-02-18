using APPLICATION.Dto.GradeBookItem;
using DOMAIN.Model;

namespace APPLICATION.IService.GradeBookData;

public interface IGradeBookItemService:IGenericService<GradeBookItem, GetGradeBookItemDto>
{
}
