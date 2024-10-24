using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSNachrichtRepository.Repository
{
    public interface IGenericRepository<T> :IDisposable
    {
         IEnumerable<T> GetAll();
         T GetEntity(int id);

         bool Add(T Entity);
         bool Delete(T Entity);
         bool Delete(int id);
         bool Update(T Entity);
        void Save();
    }
}
