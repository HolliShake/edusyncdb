using AutoMapper;
using APPLICATION.Dto.ParameterSubCategory;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class ParameterSubCategoryMapper : Profile
{
    public ParameterSubCategoryMapper()
    {
        CreateMap<ParameterSubCategoryDto, ParameterSubCategory>();
        CreateMap<ParameterSubCategory, GetParameterSubCategoryDto>();
    }
}
