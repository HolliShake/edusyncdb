
using APPLICATION.Dto.AdmissionSchedule;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class AdmissionScheduleService:GenericService<AdmissionSchedule, GetAdmissionScheduleDto>, IAdmissionScheduleService
{
    public AdmissionScheduleService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public new async Task<ICollection<GetAdmissionScheduleDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetAdmissionScheduleDto>>(await _dbModel.Include(ads => ads.Cycle).ToListAsync());
    }

    public new async Task<ICollection<GetAdmissionScheduleDto>> GetByChunk(int max)
    {
        return _mapper.Map<ICollection<GetAdmissionScheduleDto>>(await _dbModel.Include(ads => ads.Cycle).Take(max).ToListAsync());
    }

    public new async Task<AdmissionSchedule?> GetAsync(int id)
    {
        return _mapper.Map<AdmissionSchedule?>(await _dbModel.Include(ads => ads.Cycle).Where(ads => ads.Id == id).FirstOrDefaultAsync());
    }

    public async Task<ICollection<GetAdmissionScheduleDto>> GetAdmissionSchedulesByAcademicProgramId(int academicProgramId)
    {
        return _mapper.Map<ICollection<GetAdmissionScheduleDto>>(await _dbModel
            .Include(ads => ads.AcademicProgram)
            .Include(ads => ads.Cycle)
            .Where(ads => ads.AcademicProgramId == academicProgramId)
            .ToListAsync());
    }

    public async Task<ICollection<GetAdmissionScheduleDto>> GetAdmissionSchedulesByCycleId(int cycleId)
    {
        return _mapper.Map<ICollection<GetAdmissionScheduleDto>>(await _dbModel.Include(ads => ads.Cycle).Where(ads => ads.CycleId == cycleId).ToListAsync());
    }
}
