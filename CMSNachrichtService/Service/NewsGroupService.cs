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
    public class NewsGroupService : GenericService<NewsGroup>, INewsGroupService
    {
        INewsGroupRepository _newsGroupRepository;
        public NewsGroupService(DbNachrichtContext context) : base(context)
        {
            _newsGroupRepository = new NewsGroupRepository(context);
        }

        public int NextNewsGroupId()
        {
            int max = 1;
            var NewsGroupList = _newsGroupRepository.GetAll().ToList();
            if (NewsGroupList.Count>0)
            {
                max =  NewsGroupList.Max(t=> t.NewsGroupId) +1;
            }
            return max;

        }
    }
}
