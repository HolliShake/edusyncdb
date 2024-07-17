

namespace APPLICATION.Dto.FileManager;

public class GetFileTableDto
{
    public int Id { get; set; }
    public string Scope { get; set; }
    public string FileType { get; set; }
    public string FileName { get; set; }
    //
    public string ReferenceId { get; set; }
    public DateTime UploadDate { get; set; }
    public string ScopePath => (Path.Combine(Path.Join(Scope.Split(":")), FileName)).ToString().Replace(@"\\", "/").Replace(@"\", "/");
}