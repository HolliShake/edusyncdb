using APPLICATION.Dto.AcademicProgram;
using APPLICATION.Dto.Campus;
using APPLICATION.Dto.Enrollment;
using APPLICATION.Dto.Schedule;
using APPLICATION.Dto.ScheduleTeacher;
using DOMAIN.Model;

namespace APPLICATION.IService.DesignationData;

public interface IScheduleTeacherService:IGenericService<ScheduleTeacher, GetScheduleTeacherDto>
{
    public Task<bool> IsTeacher(string userId);
    public Task<object> GetScheduleTeacherByUserId(string userId);
    public Task<bool> HasShedule(string userId, int scheduleId);
    public Task<object> GetTeacherScheduleGradeBookByUserIdAndAcademicProgramId(string userId, int academicProgramId);
    public Task<object> GetTeacherScheduleGradeBookByUserId(string userId);
    public Task<ICollection<GetCampusDto>> GetTeacherScheduleWhereHeOrSheTeach(string userId);
    public Task<ICollection<GetAcademicProgramDto>> GetAcademicProgramByUserAndCampusId(string userId, int campusId);
}
