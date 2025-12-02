using AutoMapper;
using CryptoJournal.Core.DTO;
using CryptoJournal.Core.Models;

namespace CryptoJournal.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TraderRegisterDTO, Trader>()
                .ForMember(
                dest => dest.HashPassword, 
                opt => opt.MapFrom(src => src.Password));

            CreateMap<TraderUpdateDTO, Trader>()
                .ForMember(
                dest => dest.HashPassword,
                opt =>
                {
                    opt.MapFrom(src => src.Password);
                    opt.Condition(cnd => cnd.Password != null);
                });
                                        
        }
    }
}
