using AutoMapper;
using APPLICATION.Dto.EnrollmentBilling;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class EnrollmentBillingMapper : Profile
{
    public EnrollmentBillingMapper()
    {
        CreateMap<EnrollmentBillingDto, EnrollmentBilling>();
        CreateMap<EnrollmentBilling, GetEnrollmentBillingDto>();
    }
}
