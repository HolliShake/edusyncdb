using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using APPLICATION.Dto.ScheduleAttendance;
using APPLICATION.IService.SchedulingData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.SchedulingData;

public class ScheduleAttendanceService:GenericService<ScheduleAttendance, GetScheduleAttendanceDto>, IScheduleAttendanceService
{
    public ScheduleAttendanceService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<object> GetAttendanceByAnyUserId(string userId)
    {
        var attendances = await _dbModel
            .Include(sa => sa.Schedule)
                .ThenInclude(s => s.CurriculumDetail)
                    .ThenInclude(cd => cd.Course)
            .Include(sa => sa.Schedule)
                .ThenInclude(s => s.ScheduleAssignments)
                    .ThenInclude(sa => sa.Room)
                        .ThenInclude(sa => sa.Building)
            .Where(sa => sa.AnyUserId == userId)
            .ToListAsync();

        return attendances.Select(attendance =>
        {
            var buildingLocation = _dbContext.Buildings
                .Where(b => Utility.IsWithinRange((double) b.Latitude, (double) b.Longitude, (double) attendance.Latitude, (double) attendance.Longitude, 0.1)) // 100 meters
                .FirstOrDefault();

            var isPhysicallyPresent = (buildingLocation != null)
                && attendance.Schedule.ScheduleAssignments.Any(sa => sa.Room.BuildingId == buildingLocation.Id)
                && attendance.Schedule.ScheduleAssignments.Any(sa => sa.DaySchedule.Day == attendance.AttendanceDateTime.Day);

            var isLate = attendance.Schedule.ScheduleAssignments.Any(sa => sa.DaySchedule.Day == attendance.AttendanceDateTime.Day)
                && attendance.Schedule.ScheduleAssignments.Any(sa => sa.TimeScheduleIn.TimeOfDay < attendance.AttendanceDateTime.TimeOfDay);

            return (new
            {
                Id = attendance.Id,
                DateWord = attendance.AttendanceDateTime.ToString("MMMM d, yyyy", CultureInfo.CreateSpecificCulture("en-US")),
                Time = attendance.AttendanceDateTime.ToString("hh:mm tt"),
                AttendanceDateTime = attendance.AttendanceDateTime,
                IsOnSite = isPhysicallyPresent,
                IsLate = isLate,
                Building = (buildingLocation != null) ? buildingLocation.BuildingName : "N/A",
                Mode = (attendance.IsTimeIn) ? "IN" : "OUT"
            });
        });
    }

    public async Task<object?> SubmitAttendance(string userId, bool isTimeIn, int scheduleId, IFormFile file)
    {
        var geotag = Utility.GetGeoTag(file);
        var instance = new ScheduleAttendance
        {
            AttendanceDateTime = DateTime.Now,
            Latitude = (float) geotag.Latitude,
            Longitude = (float) geotag.Longitude,
            IsTimeIn = isTimeIn,
            AnyUserId = userId,
            ScheduleId = scheduleId
        };
        return await CreateAsync(instance);
    }
}
