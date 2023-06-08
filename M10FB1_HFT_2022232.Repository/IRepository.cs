using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M10FB1_HFT_2022232.Repository
{
    public interface IRepository<T> where T:class 
    {
        IQueryable<T> ReadAll();
        T ReadOne(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
