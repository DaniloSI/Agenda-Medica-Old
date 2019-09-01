using AgendaMedica.Domain.Interfaces.Repositories;

namespace AgendaMedica.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AgendaMedicaDbContext _context;

        public UnitOfWork(AgendaMedicaDbContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
