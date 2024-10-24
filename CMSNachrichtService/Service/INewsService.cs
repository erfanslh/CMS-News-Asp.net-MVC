using CMSNachrichtModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSNachrichtService.Service
{
    public interface INewsService : IGenericService<News>
    {
        IEnumerable<News> getTwoTechNews();

        IEnumerable<News> newsgroupFatures(int count);
        IEnumerable<News> mostView(int count);
        News getLastNews();
        IEnumerable<News> mostLiked(int count);

        IEnumerable<News> mySlider();
    }
}