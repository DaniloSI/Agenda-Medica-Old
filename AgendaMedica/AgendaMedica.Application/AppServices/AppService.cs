using AgendaMedica.Application.Interfaces;
using AgendaMedica.Domain.Interfaces.Domain;
using AgendaMedica.Domain.Interfaces.Repositories;
using AutoMapper;
using System;
using System.Linq;

namespace AgendaMedica.Application.AppServices
{
    public abstract class AppService<TEntity, TViewModel> : IAppService<TViewModel> where TEntity: class where TViewModel: class
    {
        protected readonly IMapper _mapper;
        private readonly IService<TEntity> _service;
        protected IUnitOfWork UoW { get; }

        public AppService(IService<TEntity> service,
            IUnitOfWork UoW,
            IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
            this.UoW = UoW;
        }

        public virtual void Add(TViewModel obj)
        {
            _service.Add(_mapper.Map<TEntity>(obj));
        }

        public void Dispose()
        {
            _service.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<TViewModel> GetAll()
        {
            return _mapper.Map<IQueryable<TViewModel>>(_service.GetAll());
        }

        public TViewModel GetById(int id)
        {
            return _mapper.Map<TViewModel>(_service.GetById(id));
        }

        public virtual void Remove(int id)
        {
            _service.Remove(id);
            UoW.Commit();
        }

        public virtual void Update(TViewModel obj)
        {
            _service.Update(_mapper.Map<TEntity>(obj));
        }

        public TViewModel GetByIdAsNoTracking(int id)
        {
            return _mapper.Map<TViewModel>(_service.GetByIdAsNoTracking(id));
        }
    }
}
