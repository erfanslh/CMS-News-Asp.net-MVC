using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSNachrichtModel.Context;
using CMSNachrichtModel.Model;

namespace CMSNachrichtRepository.Repository
{
    public class NewsRepository : GenericRepository<News>, INewsRepository
    {
        public NewsRepository(DbNachrichtContext context) : base(context)
        {
        }
    }
}
