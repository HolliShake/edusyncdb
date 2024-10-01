
using APPLICATION.Dto.AdmissionSchedule;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace INFRASTRUCTURE.Service;
public class AdmissionScheduleService:GenericService<AdmissionSchedule, GetAdmissionScheduleDto>, IAdmissionScheduleService
{
    public AdmissionScheduleService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public new async Task<ICollection<GetAdmissionScheduleDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetAdmissionScheduleDto>>(await _dbModel
            .Include(ads => ads.AcademicProgram)
            .Include(ads => ads.Cycle)
            .ToListAsync());
    }

    public new async Task<ICollection<GetAdmissionScheduleDto>> GetByChunk(int max)
    {
        return _mapper.Map<ICollection<GetAdmissionScheduleDto>>(await _dbModel
            .Include(ads => ads.AcademicProgram)
            .Include(ads => ads.Cycle)
            .Take(max).ToListAsync());
    }

    public new async Task<AdmissionSchedule?> GetAsync(int id)
    {
        return _mapper.Map<AdmissionSchedule?>(await _dbModel
            .Include(ads => ads.AcademicProgram)
            .Include(ads => ads.Cycle)
            .Where(ads => ads.Id == id)
            .FirstOrDefaultAsync());
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
        return _mapper.Map<ICollection<GetAdmissionScheduleDto>>(await _dbModel
            .Include(ads => ads.AcademicProgram)
            .Include(ads => ads.Cycle)
            .Where(ads => ads.CycleId == cycleId).ToListAsync());
    }

    public async new Task<bool> CreateAsync(AdmissionSchedule newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result)
        {
            newItem.AcademicProgram = await _dbContext.AcademicPrograms.FindAsync(newItem.AcademicProgramId);
            newItem.Cycle = await _dbContext.Cycles.FindAsync(newItem.CycleId);
        }
        return result;
    }

    public async new Task<bool> UpdateSync(AdmissionSchedule updatedItem)
    {
        _dbModel.Update(updatedItem);
        var result = await Save();
        if (result)
        {
            updatedItem.AcademicProgram = await _dbContext.AcademicPrograms.FindAsync(updatedItem.AcademicProgramId);
            updatedItem.Cycle = await _dbContext.Cycles.FindAsync(updatedItem.CycleId);
        }
        return result;
    }

    public async Task<object> GetOpenAdmissionScheduleGroupedByCampus(int schoolId)
    {
        // Query for admission schedules with conditions
        var admissionSchedules = await _dbModel
            .Include(a => a.AcademicProgram)
                .ThenInclude(ap => ap.College)
                    .ThenInclude(c => c.Campus)
            .Where(a => a.AcademicProgram.College.Campus.AgencyId == schoolId)
            .Where(a =>
                (a.StartDate >= DateTime.Now && a.EndDate <= DateTime.Now) ||
                (a.StartDate >= DateTime.Now && !a.IsClosedOverride))
            .ToListAsync();

        // Group by campus
        var groupedByCampus = admissionSchedules
            .GroupBy(a => a.AcademicProgram.College.Campus)
            .Select(campusGroup => new
            {
                CampusId = campusGroup.Key.Id,
                CampusName = campusGroup.Key.CampusName,
                Colleges = campusGroup
                    .GroupBy(a => a.AcademicProgram.College)
                    .Select(collegeGroup => new
                    {
                        CollegeId = collegeGroup.Key.Id,
                        CollegeName = collegeGroup.Key.CollegeName,
                        AdmissionSchedules = collegeGroup
                            .GroupBy(a => a.CycleId)
                            .Select(cycleGroup => new
                            {
                                AdmissionScheduleId = cycleGroup.First().Id,
                                CycleId = cycleGroup.Key,
                                Cycle = cycleGroup.First().Cycle,
                                AcademicPrograms = cycleGroup
                                    .Select(a => new
                                    {
                                        AcademicProgramId = a.AcademicProgramId,
                                        AcademicProgramName = a.AcademicProgram.ProgramName
                                    }).ToList()
                            }).ToList()
                    }).ToList()
            }).ToList();
        return groupedByCampus;
    }

    // TODO: Implement this method
    public async Task<object> GetOpenAdmissionScheduleGroupedByCampusViaCampusName(string campusShortName)
    {
        // Query for admission schedules with conditions
        var admissionSchedules = await _dbModel
            .Include(a => a.AcademicProgram)
                .ThenInclude(ap => ap.College)
                    .ThenInclude(c => c.Campus)
            .Where(a =>
                (a.StartDate >= DateTime.Now && a.EndDate <= DateTime.Now) ||
                (a.StartDate >= DateTime.Now && !a.IsClosedOverride))
            .ToListAsync();

        // Group by campus
        var groupedByCampus = admissionSchedules
            .GroupBy(a => a.AcademicProgram.College.Campus)
            .Where(a => a.Key.CampusShortName == campusShortName)
            .Select(campusGroup => new
            {
                CampusId = campusGroup.Key.Id,
                CampusName = campusGroup.Key.CampusName,
                Colleges = campusGroup
                    .GroupBy(a => a.AcademicProgram.College)
                    .Select(collegeGroup => new
                    {
                        CollegeId = collegeGroup.Key.Id,
                        CollegeName = collegeGroup.Key.CollegeName,
                        AdmissionSchedules = collegeGroup
                            .GroupBy(a => a.CycleId)
                            .Select(cycleGroup => new
                            {
                                AdmissionScheduleId = cycleGroup.First().Id,
                                CycleId = cycleGroup.Key,
                                Cycle = cycleGroup.First().Cycle,
                                AcademicPrograms = cycleGroup
                                    .Select(a => new
                                    {
                                        AcademicProgramId = a.AcademicProgramId,
                                        AcademicProgramName = a.AcademicProgram.ProgramName
                                    }).ToList()
                            }).ToList()
                    }).ToList()
            }).ToList();
        return groupedByCampus;
    }
}
