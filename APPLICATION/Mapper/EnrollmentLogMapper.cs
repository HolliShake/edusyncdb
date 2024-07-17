using AutoMapper;
using APPLICATION.Dto.EnrollmentLog;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class EnrollmentLogMapper : Profile
{
    public EnrollmentLogMapper()
    {
        CreateMap<EnrollmentLogDto, EnrollmentLog>();
        CreateMap<EnrollmentLog, GetEnrollmentLogDto>();
    }
}
