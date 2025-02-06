using AutoMapper;
using WebAPICodeFirst.DB.Entity;
using WebAPICodeFirst.DTO.Player;
using WebAPICodeFirst.DTO.PlayerInstrument;

namespace WebAPICodeFirst
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Player, CreatePlayerRequest>().ReverseMap();
            CreateMap<Player, UpdatePlayerRequest>().ReverseMap();
            CreateMap<Player, GetPlayerDetailResponse>().ReverseMap();
            CreateMap<Player, GetPlayerResponse>().ForMember(dest => dest.InstrumentSubmittedCount, opt=>opt.MapFrom(src => src.Instruments.Count)).ReverseMap();
            CreateMap<PlayerInstrument, CreatePlayerInstrumentRequest>().ReverseMap();
            CreateMap<PlayerInstrument, GetPlayerInstrumentResponse>().ReverseMap();
        }
    }
}
