using AutoMapper;
using APPLICATION.Dto.CourseFee;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class CourseFeeMapper : Profile
{
    public CourseFeeMapper()
    {
        CreateMap<CourseFeeDto, CourseFee>();
        CreateMap<CourseFee, GetCourseFeeDto>();
    }
}
