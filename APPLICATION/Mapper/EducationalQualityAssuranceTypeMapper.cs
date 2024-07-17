using AutoMapper;
using APPLICATION.Dto.EducationalQualityAssuranceType;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class EducationalQualityAssuranceTypeMapper : Profile
{
    public EducationalQualityAssuranceTypeMapper()
    {
        CreateMap<EducationalQualityAssuranceTypeDto, EducationalQualityAssuranceType>();
        CreateMap<EducationalQualityAssuranceType, GetEducationalQualityAssuranceTypeDto>();
    }
}
