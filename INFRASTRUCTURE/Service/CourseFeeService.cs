using APPLICATION.Dto.CourseFee;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class CourseFeeService:GenericService<CourseFee, GetCourseFeeDto>, ICourseFeeService
{
    public CourseFeeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
