using AutoMapper;
using WebApi.Data;
using WebApi.Models.Address;

namespace WebApi.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AddressCreateDto, Address>().ReverseMap();
            CreateMap<AddressReadOnlyDto, Address>().ReverseMap();
            CreateMap<AddressUpdateDto, Address>().ReverseMap();

        }
    }
}
