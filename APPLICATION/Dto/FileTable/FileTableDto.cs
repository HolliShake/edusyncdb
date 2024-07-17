using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.FileTable;
public class FileTableDto
{
    public int Id { get; set; }
    public string Scope { get; set; }
    public string FileType { get; set; }
    public string FileName { get; set; }
    //
    public string ReferenceId { get; set; }
    public DateTime UploadDate { get; set; }
}
