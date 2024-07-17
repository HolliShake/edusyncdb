
namespace DOMAIN.Model;

public enum CourseRequisiteType
{
    CoRequisite  = 0x0,
    PreRequisite = 0x1,
    Equivalent   = 0x2
}

public class CourseRequisiteValue
{
    public CourseRequisiteType value;

    public CourseRequisiteValue(CourseRequisiteType courseRequisiteType)
    {
        value = courseRequisiteType;
    }

    public string Label => value.ToString();
}