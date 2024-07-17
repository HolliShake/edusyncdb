using AutoMapper;
using APPLICATION.Dto.GraduationApplicant;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class GraduationApplicantMapper : Profile
{
    public GraduationApplicantMapper()
    {
        CreateMap<GraduationApplicantDto, GraduationApplicant>();
        CreateMap<GraduationApplicant, GetGraduationApplicantDto>();
    }
}
