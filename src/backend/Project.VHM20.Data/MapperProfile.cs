using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Project.VHM20.Data.Entities;

namespace Project.VHM20.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Cliente, ClienteDto>()
                .ReverseMap()
                .EqualityComparison((dto, o) => dto.Id == o.Id);
        }
    }
}