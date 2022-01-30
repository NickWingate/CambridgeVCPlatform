using AutoMapper;
using WebApi.Data;
using WebApi.Models.Address;
using WebApi.Models.SessionTimings;
using WebApi.Models.Squads;

namespace WebApi.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AddressCreateDto, Address>().ReverseMap();
            CreateMap<AddressReadOnlyDto, Address>().ReverseMap();
            CreateMap<AddressUpdateDto, Address>().ReverseMap();

            CreateMap<SessionTimingCreateDto, SessionTiming>().ReverseMap();
            CreateMap<SessionTimingReadOnlyDto, SessionTiming>().ReverseMap();
            CreateMap<SessionTimingUpdateDto, SessionTiming>().ReverseMap();

            CreateMap<SquadCreateDto, Squad>().ReverseMap();

        }
    }
}
