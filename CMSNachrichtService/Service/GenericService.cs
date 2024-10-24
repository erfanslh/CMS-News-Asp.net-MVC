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
    public class GenericService<T> : GenericRepository<T> where T : BaseEntity
    {
        public GenericService(DbNachrichtContext context) : base(context)
        {
        }
    }
}

