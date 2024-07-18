using APPLICATION.Dto.GradeInput;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class GradeInputService:GenericService<GradeInput, GetGradeInputDto>, IGradeInputService
{
    public GradeInputService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
