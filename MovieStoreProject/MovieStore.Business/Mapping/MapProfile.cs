using AutoMapper;
using MovieStore.Core.DataTransferObjects;
using MovieStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Business.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Actor, ActorDto>().ReverseMap();
            CreateMap<Director, DirectorDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Movie, MovieWithDirectorDto>();
        }
    }
}
