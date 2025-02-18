using APPLICATION.Dto.ScheduleAssignment;
using DOMAIN.Model;

namespace APPLICATION.IService.SchedulingData;

public interface IScheduleAssignmentService:IGenericService<ScheduleAssignment, GetScheduleAssignmentDto>
{
    public Task<object> CreateScheduleAssignmentByMergeCode(string mergeCode, ScheduleAssignmentMergeCodeDto item);
    public Task<object> DeleteScheduleAssignmentByMergeCode(string mergeCode);
}
