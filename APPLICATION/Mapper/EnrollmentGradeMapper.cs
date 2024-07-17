using AutoMapper;
using APPLICATION.Dto.EnrollmentGrade;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class EnrollmentGradeMapper : Profile
{
    public EnrollmentGradeMapper()
    {
        CreateMap<EnrollmentGradeDto, EnrollmentGrade>();
        CreateMap<EnrollmentGrade, GetEnrollmentGradeDto>();
    }
}
