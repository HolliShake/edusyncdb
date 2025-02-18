using AutoMapper;
using APPLICATION.Dto.CourseFee;
using APPLICATION.IService.AccountingData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.AccountingData;

public class CourseFeeService:GenericService<CourseFee, GetCourseFeeDto>, ICourseFeeService
{
    public CourseFeeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
