using System.Collections.Generic;
using System.Linq;

namespace CadeMeuPet.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> Get();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
