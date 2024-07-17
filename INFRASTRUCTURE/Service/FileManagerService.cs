using System.Runtime.InteropServices;
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace INFRASTRUCTURE.Service;

public class FileManagerService : GenericService<FileTable>, IFileManagerService
{
    public FileManagerService(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<FileTable>> GetFileByScope(string scope)
    {
        return await _dbModel.Where(file => file.Scope.Equals(scope)).ToListAsync();
    }

    public async Task<List<FileTable>> GetFileByScopeAndReferenceId(string scope, int referenceId)
    {
        return await _dbModel.Where(file => file.Scope.Equals(scope) && file.ReferenceId.Equals(referenceId.ToString())).ToListAsync();
    }

    public async Task<FileTable?> UploadFile(ConfigurationManager configuration, string scope, int referenceId, IFormFile file)
    {
        var uploadPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? Path.Combine(configuration["File:LocationWIN32"], configuration["File:DestinationWIN32"])
            : Path.Combine(configuration["File:LocationLINUX"], configuration["File:DestinationLINUX"]);

        var names = file.FileName.Split('.');
        var extension = "." + names[^1];

        string fileName;
        try
        {
            fileName = Path.GetRandomFileName() + $"-{Guid.NewGuid()}" + extension;
            var targetPath = Path.Combine(uploadPath, "");

            var segments = scope.Split(":");
            foreach (var segment in segments)
            {
                targetPath = Path.Combine(targetPath, segment);

                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);
                }
            }

            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);

                var stream = new FileStream(Path.Combine(targetPath, fileName), FileMode.Create);
                await file.CopyToAsync(stream);
            }
            else
            {
                // Store
                var stream = new FileStream(Path.Combine(targetPath, fileName), FileMode.Create);
                await file.CopyToAsync(stream);
            }
        }
        catch (Exception)
        {
            return null;
        }

        var result = await _dbModel.AddAsync(new FileTable
        {
            FileName = fileName,
            FileType = extension,
            Scope = scope,
            ReferenceId = referenceId.ToString()
        });

        return (await Save())
            ? result.Entity
            : null;
    }

    public async Task<ICollection<FileTable>?> UploadMultipleFile(ConfigurationManager configuration, string scope, int referenceId, List<IFormFile> files)
    {
        var uploadPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? Path.Combine(configuration["File:LocationWIN32"], configuration["File:DestinationWIN32"])
            : Path.Combine(configuration["File:LocationLINUX"], configuration["File:DestinationLINUX"]);

        if (files.Count <= 0)
        {
            return null;
        }

        var items = new List<FileTable>();

        foreach (var file in files)
        {
            var names = file.FileName.Split('.');
            var extension = "." + names[^1];

            string fileName;
            try
            {
                fileName = Path.GetRandomFileName() + $"-{Guid.NewGuid()}" + extension;
                var targetPath = Path.Combine(uploadPath, "");

                var segments = scope.Split(":");
                foreach (var segment in segments)
                {
                    targetPath = Path.Combine(targetPath, segment);

                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }
                }

                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);

                    var stream = new FileStream(Path.Combine(targetPath, fileName), FileMode.Create);
                    await file.CopyToAsync(stream);
                }
                else
                {
                    // Store
                    var stream = new FileStream(Path.Combine(targetPath, fileName), FileMode.Create);
                    await file.CopyToAsync(stream);
                }

                items.Add(new FileTable
                {
                    FileName = fileName,
                    FileType = extension,
                    Scope = scope,
                    ReferenceId = referenceId.ToString()
                });
            }
            catch (Exception)
            {
                return null;
            }
        }

        await _dbModel.AddRangeAsync(items);

        return (await Save())
            ? items
            : null;
    }
}