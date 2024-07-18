using APPLICATION.Dto.GradeBook;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IGradeBookService:IGenericService<GradeBook, GetGradeBookDto>
{
}
