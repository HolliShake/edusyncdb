using DOMAIN.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace APPLICATION.IService;

public interface IFileManagerService : IGenericService<FileTable>
{
    public Task<List<FileTable>> GetFileByScope(string scope);
    public Task<List<FileTable>> GetFileByScopeAndReferenceId(string scope, int referenceId);
    public Task<FileTable?> UploadFile(ConfigurationManager configuration, string scope, int referenceId, IFormFile file);
    public Task<ICollection<FileTable>?> UploadMultipleFile(ConfigurationManager configuration, string scope, int referenceId, List<IFormFile> files);
}