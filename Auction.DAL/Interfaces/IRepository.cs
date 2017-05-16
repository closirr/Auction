using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Interfaces
{
    public interface IRepository<T,TInput> where T:class
    {
        IQueryable<T> GetAll();
        T Get(TInput id);
        void Create(T item);
        void Update(T item);
        void Delete(TInput id);
    }
}
