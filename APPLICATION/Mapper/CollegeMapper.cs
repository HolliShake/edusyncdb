using AutoMapper;
using APPLICATION.Dto.College;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class CollegeMapper : Profile
{
    public CollegeMapper()
    {
        CreateMap<CollegeDto, College>();
        CreateMap<College, GetCollegeDto>();
    }
}
