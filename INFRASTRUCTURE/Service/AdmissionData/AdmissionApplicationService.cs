using AutoMapper;
using Microsoft.EntityFrameworkCore;
using APPLICATION.Dto.AdmissionApplication;
using APPLICATION.IService.AdmissionData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.AdmissionData;

public class AdmissionApplicationService:GenericService<AdmissionApplication, GetAdmissionApplicationDto>, IAdmissionApplicationService
{
    public AdmissionApplicationService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetAdmissionApplicationDto>> GetAdmissionApplicationsByAdmissionScheduleId(int admissionScheduleId)
    {
        var admissionApplications = await _dbModel
        .Where(aa => aa.AdmissionScheduleId == admissionScheduleId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetAdmissionApplicationDto>>(admissionApplications);
    }
}
