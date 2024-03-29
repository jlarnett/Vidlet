﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidlet.Dtos;
using Vidlet.Models;

namespace Vidlet.App_Start
{
    public class MappingProfile : Profile
    {

        //Used for AutoMapper package. Creates link between Models and Dtos so they can be mapped to each other efficiently.
        public MappingProfile()
        {
            //Create Mapping between Models & DTOS.
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}