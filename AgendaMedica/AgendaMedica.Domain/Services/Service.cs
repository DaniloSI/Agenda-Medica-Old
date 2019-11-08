using AgendaMedica.Domain.Interfaces.Domain;
using AgendaMedica.Domain.Interfaces.Repositories;
using System;
using System.Linq;

namespace AgendaMedica.Domain.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public TEntity GetByIdAsNoTracking(int id)
        {
            return _repository.GetByIdAsNoTracking(id);
        }

        public virtual void Remove(int id)
        {
            _repository.Remove(id);
        }

        public int SaveChanges()
        {
            return _repository.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            _repository.Update(obj);
        }
    }
}
