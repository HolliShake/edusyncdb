
using APPLICATION.Dto.FileManager;
using AutoMapper;
using DOMAIN.Model;

namespace APPLICATION.Mapper;

public class FileManagerMapper : Profile
{
    public FileManagerMapper()
    {
        CreateMap<FileTable, GetFileManagerTableDto>();
    }
}