using System;
using System.Linq;

namespace AgendaMedica.Domain.Interfaces.Domain
{
    public interface IService<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(int id);
        int SaveChanges();
        TEntity GetByIdAsNoTracking(int id);
    }
}
