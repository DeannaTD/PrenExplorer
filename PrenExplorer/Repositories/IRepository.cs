using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrenExplorer.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        //CRUD
        Task CreateAsync(T entity);
        ValueTask<T> GetByIdAsync(object id);
        Task<List<T>> GetCollectionAsync();
        void Update(T entity);
        void Delete(T entity);
    }
}
