using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CMSNachricht.Models.ViewModel;
using CMSNachrichtModel.Model;

namespace WebApplication3.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper mapper;

        public static void ConfigureMapping()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(t =>
            {
                t.CreateMap<NewsGroup, NewsGroupViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<NewsGroupViewModel, NewsGroup>().IgnoreAllPropertiesWithAnInaccessibleSetter();


                t.CreateMap<NewsViewModel, News>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<News, NewsViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();

                t.CreateMap<Comment, CommentViewModel>().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
                t.CreateMap<CommentViewModel, Comment>().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            
                t.CreateMap<Author, AuthorViewModel>().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
                t.CreateMap<AuthorViewModel, Author>().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            });
            mapper = mapperConfiguration.CreateMapper();
        }
    }
}