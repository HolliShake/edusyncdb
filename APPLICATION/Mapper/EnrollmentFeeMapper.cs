using AutoMapper;
using APPLICATION.Dto.EnrollmentFee;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class EnrollmentFeeMapper : Profile
{
    public EnrollmentFeeMapper()
    {
        CreateMap<EnrollmentFeeDto, EnrollmentFee>();
        CreateMap<EnrollmentFee, GetEnrollmentFeeDto>();
    }
}
