using AutoMapper;
using peliculasApi.DTOs;
using peliculasApi.Entity;

namespace peliculasApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Genre, GenreDTO>().ReverseMap();
            CreateMap<GenreCreationDTO, Genre>().ReverseMap();
            CreateMap<Actor, ActorDTO>().ReverseMap();
            CreateMap<ActorCreationDTO, Actor>().ReverseMap();
        }
    }
}
