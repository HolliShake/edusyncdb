using AutoMapper;
using APPLICATION.Dto.Enrollment;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class EnrollmentMapper : Profile
{
    public EnrollmentMapper()
    {
        CreateMap<EnrollmentDto, Enrollment>();
        CreateMap<Enrollment, GetEnrollmentDto>();
    }
}
