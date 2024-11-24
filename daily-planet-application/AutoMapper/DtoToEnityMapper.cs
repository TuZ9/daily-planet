using AutoMapper;
using daily_planet_domain.Dto;
using daily_planet_domain.Entities;

namespace daily_planet_application.AutoMapper
{
    public class DtoToEnityMapper : Profile
    {
        public DtoToEnityMapper()
        {
            CreateMap<NewsDto, News>();
        }
    }
}
