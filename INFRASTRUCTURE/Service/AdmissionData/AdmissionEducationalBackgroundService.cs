using APPLICATION.Dto.AdmissionEducationalBackground;
using APPLICATION.IService.AdmissionData;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.AdmissionData;

public class AdmissionEducationalBackgroundService:GenericService<AdmissionEducationalBackground, GetAdmissionEducationalBackgroundDto>, IAdmissionEducationalBackgroundService
{
    public AdmissionEducationalBackgroundService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
