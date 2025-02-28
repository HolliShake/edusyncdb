namespace APPLICATION.IService.SharedData;

public interface ISharedData
{
    public Task<object> GetStudentsByContext(
        int referenceId,
        int page,
        int rows,
        ContextType type
    );

    public Task<object> GetTeachersByContext(
        int referenceId,
        int page,
        int rows,
        ContextType type
    );

    public Task<object> GetCurriculumByContext(
        int referenceId,
        int page,
        int rows,
        ContextType type
    );
}