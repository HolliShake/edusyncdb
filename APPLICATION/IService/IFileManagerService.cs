using APPLICATION.Dto.FileManager;
using DOMAIN.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace APPLICATION.IService;

public interface IFileManagerService : IGenericService<FileTable, GetFileManagerTableDto>
{
    public Task<List<GetFileManagerTableDto>> GetFileByScope(string scope);
    public Task<List<GetFileManagerTableDto>> GetFileByScopeAndReferenceId(string scope, int referenceId);
    public Task<GetFileManagerTableDto?> UploadFile(ConfigurationManager configuration, string scope, int referenceId, IFormFile file);
    public Task<ICollection<GetFileManagerTableDto>?> UploadMultipleFile(ConfigurationManager configuration, string scope, int referenceId, List<IFormFile> files);
}