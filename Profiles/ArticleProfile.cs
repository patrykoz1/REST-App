using AutoMapper;
using RestApp.Dtos;
using RestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApp.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile() {
            //source -- > destination (from: to)
            CreateMap<Article, ArticleReadDto>();
            CreateMap<ArticleAddDto,Article>();
        }
    }
}
