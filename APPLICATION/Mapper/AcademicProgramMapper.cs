using AutoMapper;
using APPLICATION.Dto.AcademicProgram;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class AcademicProgramMapper : Profile
{
    public AcademicProgramMapper()
    {
        CreateMap<AcademicProgramDto, AcademicProgram>();
        CreateMap<AcademicProgram, GetAcademicProgramDto>();
    }
}
