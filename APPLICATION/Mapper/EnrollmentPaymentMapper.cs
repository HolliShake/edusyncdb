using AutoMapper;
using APPLICATION.Dto.EnrollmentPayment;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class EnrollmentPaymentMapper : Profile
{
    public EnrollmentPaymentMapper()
    {
        CreateMap<EnrollmentPaymentDto, EnrollmentPayment>();
        CreateMap<EnrollmentPayment, GetEnrollmentPaymentDto>();
    }
}
