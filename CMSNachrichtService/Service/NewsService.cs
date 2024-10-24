using CMSNachrichtModel.Context;
using CMSNachrichtModel.Model;
using CMSNachrichtRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSNachrichtService.Service
{
    public class NewsService : GenericService<News>, INewsService
    {
        NewsRepository _newsRepository;
        public NewsService(DbNachrichtContext context) : base(context)
        {
            _newsRepository = new NewsRepository(context);
        }

        public News getLastNews()
        {
            return _newsRepository.GetAll().Where(t => t.IsActive).OrderByDescending(t => t.NewsId).LastOrDefault();
        }

        public IEnumerable<News> getTwoTechNews()
        {
            return _newsRepository.GetAll().Where(t => t.NewsGroupId == 5 && t.IsActive).OrderByDescending(t => t.RegisterDate).Take(2);
        }

        public IEnumerable<News> mostLiked(int count)
        {
            return _newsRepository.GetAll().Where(t => t.IsActive).OrderByDescending(t => t.Like).Take(count);
        }

        public IEnumerable<News> mostView(int count)
        {
            return _newsRepository.GetAll().Where(t => t.IsActive).OrderByDescending(u => u.See).Take(count);
        }

        public IEnumerable<News> newsgroupFatures(int count)
        {

            return _newsRepository.GetAll().OrderByDescending(u => u.NewsGroupId).Take(count);
        }

        public IEnumerable<News> mySlider()
        {
            return _newsRepository.GetAll().Where(t => t.IsActive).OrderByDescending(u => u.NewsId);
        }
    }
}
