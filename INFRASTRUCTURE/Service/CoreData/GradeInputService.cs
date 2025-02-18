using AutoMapper;
using APPLICATION.Dto.GradeInput;
using APPLICATION.IService.CoreData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.CoreData;

public class GradeInputService:GenericService<GradeInput, GetGradeInputDto>, IGradeInputService
{
    public GradeInputService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
