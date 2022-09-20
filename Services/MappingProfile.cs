using AutoMapper;
using Entities;
using Models;
using SharedObjects.DataTransferObjects;

namespace Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //HandModel -> Hand
            CreateMap<HandModel, Hand>()
                .ForMember(dest => dest.Cards, opt => opt.MapFrom(src => src));

            CreateMap<HandModel, Hand>()
               .ForMember(dest => dest, opt => opt.MapFrom(src => src.Cards));

            CreateMap<CardModel, Card>();

            CreateMap<HandModel, Hand>().ReverseMap()
                .ForMember(dest => dest.Cards, opt => opt.MapFrom(src => src));

            CreateMap<HandModel, Hand>().ReverseMap()
                .ForMember(dest => dest, opt => opt.MapFrom(src => src.Cards));

            CreateMap<CardModel, Card>().ReverseMap();

            ///////////////////
        }
    }
}

