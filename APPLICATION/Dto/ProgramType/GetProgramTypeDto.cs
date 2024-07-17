using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ProgramType;
public class GetProgramTypeDto
{
    public int Id { get; set; }
    public string ProgramTypeName { get; set; }
}
