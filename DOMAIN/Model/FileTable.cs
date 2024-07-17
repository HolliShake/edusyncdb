namespace DOMAIN.Model;

public class FileTable
{
    public int Id { get; set; }
    public string Scope { get; set; }
    public string FileType { get; set; }
    public string FileName { get; set; }
    //
    public string ReferenceId { get; set; }
    public DateTime UploadDate { get; set; }
}