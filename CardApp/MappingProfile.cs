using AutoMapper;
using Entities;
using SharedObjects.DataTransferObjects;

namespace CardApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Hand, HandDto>();

            CreateMap<Hand, HandDto>().ReverseMap();

            CreateMap<HandForCreationDto, Hand>();

            CreateMap<HandForCreationDto, Hand>().ReverseMap();
        }
    }
}

