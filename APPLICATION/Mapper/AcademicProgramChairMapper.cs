using AutoMapper;
using APPLICATION.Dto.AcademicProgramChair;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class AcademicProgramChairMapper : Profile
{
    public AcademicProgramChairMapper()
    {
        CreateMap<AcademicProgramChairDto, AcademicProgramChair>();
        CreateMap<AcademicProgramChair, GetAcademicProgramChairDto>();
    }
}
