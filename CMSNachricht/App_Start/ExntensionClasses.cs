using CMSNachricht.Models.ViewModel;
using CMSNachrichtModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.App_Start;

namespace CMSNachricht.App_Start
{
    public static class ExntensionClasses
    {
        public static List<NewsViewModel> ToNewsViewModels (this IEnumerable<News> news)
        {
            return AutoMapperConfig.mapper.Map<IEnumerable<News>, List<NewsViewModel>>(news);
        }

        public static NewsViewModel ToNewsViewModel (this News news)
        {
            return AutoMapperConfig.mapper.Map<News, NewsViewModel>(news);
        }
    }
}