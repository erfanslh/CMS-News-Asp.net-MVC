using CMSNachrichtModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSNachrichtService.Service
{
    public interface IGenericService<T> where T:BaseEntity
    {
    }
}
