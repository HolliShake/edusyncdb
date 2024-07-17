using AutoMapper;
using APPLICATION.Dto.TableObject;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class TableObjectMapper : Profile
{
    public TableObjectMapper()
    {
        CreateMap<TableObjectDto, TableObject>();
        CreateMap<TableObject, GetTableObjectDto>();
    }
}
