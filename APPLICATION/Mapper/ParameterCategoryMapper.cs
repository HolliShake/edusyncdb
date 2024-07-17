using AutoMapper;
using APPLICATION.Dto.ParameterCategory;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class ParameterCategoryMapper : Profile
{
    public ParameterCategoryMapper()
    {
        CreateMap<ParameterCategoryDto, ParameterCategory>();
        CreateMap<ParameterCategory, GetParameterCategoryDto>();
    }
}
