using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaMedica.Application.Interfaces
{
    public interface IAppService<TViewModel> : IDisposable where TViewModel : class
    {
        void Add(TViewModel obj);
        TViewModel GetById(int id);
        IQueryable<TViewModel> GetAll();
        void Update(TViewModel obj);
        void Remove(int id);
    }
}
