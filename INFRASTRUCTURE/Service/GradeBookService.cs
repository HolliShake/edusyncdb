using APPLICATION.Dto.GradeBook;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class GradeBookService:GenericService<GradeBook, GetGradeBookDto>, IGradeBookService
{
    public GradeBookService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
