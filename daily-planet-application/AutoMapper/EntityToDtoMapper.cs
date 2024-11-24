using AutoMapper;
using daily_planet_domain.Dto;
using daily_planet_domain.Entities;

namespace daily_planet_application.AutoMapper
{
    public class EntityToDtoMapper : Profile
    {
        public EntityToDtoMapper()
        {
            CreateMap<News, NewsDto>();
        }
    }
}
