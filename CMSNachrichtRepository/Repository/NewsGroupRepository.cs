using CMSNachrichtModel.Context;
using CMSNachrichtModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSNachrichtRepository.Repository
{
    public class NewsGroupRepository : GenericRepository<NewsGroup>, INewsGroupRepository
    {
        public NewsGroupRepository(DbNachrichtContext context) : base(context)
        {
        }
    }
}
