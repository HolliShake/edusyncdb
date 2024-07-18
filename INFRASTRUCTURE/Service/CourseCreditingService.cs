using APPLICATION.Dto.CourseCrediting;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class CourseCreditingService:GenericService<CourseCrediting, GetCourseCreditingDto>, ICourseCreditingService
{
    public CourseCreditingService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
