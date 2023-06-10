using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M10FB1_HFT_2022232.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected MusicDbContext mdb;

        protected Repository(MusicDbContext mdb)
        {
            this.mdb = mdb;
        }

        public void Create(T item)
        {
            mdb.Set<T>().Add(item);
            mdb.SaveChanges();
        }

        public void Delete(int id)
        {
            mdb.Set<T>().Remove(Read(id));
            mdb.SaveChanges();
        }
        
        public IQueryable<T> ReadAll()
        {
            return mdb.Set<T>();
        }

        public abstract T Read(int id);
     

        public abstract void Update(T item);
        
    }
}
