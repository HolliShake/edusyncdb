using APPLICATION.Dto.GradeBook;
using DOMAIN.Model;

namespace APPLICATION.IService.GradeBookData;

public interface IGradeBookService:IGenericService<GradeBook, GetGradeBookDto>
{
    public Task<object?> GenerateGradeBookFromTemplate(int scheduleId, int templateGradeBookId);
    public Task<object?> GetGradeBookByScheduleId(int scheduleId);
}
