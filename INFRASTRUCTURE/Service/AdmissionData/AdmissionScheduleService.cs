using AutoMapper;
using Microsoft.EntityFrameworkCore;
using APPLICATION.Dto.AdmissionSchedule;
using APPLICATION.IService.AdmissionData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.AdmissionData;

public class AdmissionScheduleService:GenericService<AdmissionSchedule, GetAdmissionScheduleDto>, IAdmissionScheduleService
{
    public AdmissionScheduleService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public new async Task<ICollection<GetAdmissionScheduleDto>> GetAllAsync()
    {
        var admissionSchedules = await _dbModel
        .Include(ads => ads.AcademicProgram)
        .Include(ads => ads.Cycle)
        .ToListAsync();
        return _mapper.Map<ICollection<GetAdmissionScheduleDto>>(admissionSchedules);
    }

    public new async Task<ICollection<GetAdmissionScheduleDto>> GetByChunk(int max)
    {
        var admissionSchedules = await _dbModel
        .Include(ads => ads.AcademicProgram)
        .Include(ads => ads.Cycle)
        .Take(max)
        .ToListAsync();
        return _mapper.Map<ICollection<GetAdmissionScheduleDto>>(admissionSchedules);

    }

    public new async Task<AdmissionSchedule?> GetAsync(int id)
    {
        var admissionSchedule = await _dbModel
        .Include(ads => ads.AcademicProgram)
        .Include(ads => ads.Cycle)
        .AsNoTracking()
        .SingleOrDefaultAsync(ads => ads.Id == id);
        return admissionSchedule;
    }

    public async Task<ICollection<GetAdmissionScheduleDto>> GetAdmissionSchedulesByAcademicProgramId(int academicProgramId)
    {
        var admissionSchedules = await _dbModel
        .Include(ads => ads.AcademicProgram)
        .Include(ads => ads.Cycle)
        .Where(ads => ads.AcademicProgramId == academicProgramId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetAdmissionScheduleDto>>(admissionSchedules);
    }

    public async Task<ICollection<GetAdmissionScheduleDto>> GetAdmissionSchedulesByCycleId(int cycleId)
    {
        var admissionSchedules = await _dbModel
        .Include(ads => ads.AcademicProgram)
        .Include(ads => ads.Cycle)
        .Where(ads => ads.CycleId == cycleId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetAdmissionScheduleDto>>(admissionSchedules);
    }

    public async new Task<GetAdmissionScheduleDto?> CreateAsync(AdmissionSchedule newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.AcademicProgram = _dbContext.AcademicPrograms.Find(newItem.AcademicProgramId);
            newItem.Cycle = _dbContext.Cycles.Find(newItem.CycleId);
            return _mapper.Map<GetAdmissionScheduleDto>(newItem);
        }
        return null;
    }

    public async new Task<GetAdmissionScheduleDto?> UpdateAsync(AdmissionSchedule updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.AcademicProgram = _dbContext.AcademicPrograms.Find(updatedItem.AcademicProgramId);
            updatedItem.Cycle = _dbContext.Cycles.Find(updatedItem.CycleId);
            return _mapper.Map<GetAdmissionScheduleDto>(updatedItem);
        }
        return null;
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
