
using APPLICATION.Dto.TemplateGradeBook;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface ITemplateGradeBookService:IGenericService<TemplateGradeBook, GetTemplateGradeBookDto>
{
    public Task<object?> TemplateGroupCreate(TemplateGradeBookGroupDto template);
    public Task<object> GetAllAsStructuredAsync();
}
