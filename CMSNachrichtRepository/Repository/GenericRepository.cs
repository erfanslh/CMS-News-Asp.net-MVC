using CMSNachrichtModel.Context;
using CMSNachrichtModel.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSNachrichtRepository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        DbNachrichtContext db;
        DbSet<T> dbset;
        public GenericRepository(DbNachrichtContext context)
        {
            db = context;
            dbset = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public T GetEntity(int id)
        {
            var Entity = dbset.Find(id);
            return Entity;
        }
        public bool Add(T Entity)
        {
            try
            {
                dbset.Add(Entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(T Entity)
        {
            try
            {
                db.Entry(Entity).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            };
        }

        public bool Delete(int id)
        {
          
                var Entity = dbset.Find(id);
                if (Entity != null)
                {
                    db.Entry(Entity).State = EntityState.Deleted;
                    return true;
                }
                else
                {
                return false;
                }
        }


        public bool Update(T Entity)
        {
            try
            {
                db.Entry(Entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }


    }
}
