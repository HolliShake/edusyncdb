using AutoMapper;
using APPLICATION.Dto.FileTable;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class FileTableMapper : Profile
{
    public FileTableMapper()
    {
        CreateMap<FileTableDto, FileTable>();
        CreateMap<FileTable, GetFileTableDto>();
    }
}
