using System;
using System.Linq;

namespace AgendaMedica.Application.Interfaces
{
    public interface IAppService<TViewModel> : IDisposable where TViewModel : class
    {
        void Add(TViewModel obj);
        TViewModel GetById(int id);
        TViewModel GetByIdAsNoTracking(int id);
        IQueryable<TViewModel> GetAll();
        void Update(TViewModel obj);
        void Remove(int id);
    }
}
