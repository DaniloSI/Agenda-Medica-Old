using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces.Repositories;

namespace AgendaMedica.Data.Repositories
{
    public class EspecialidadeRepository : Repository<Especialidade>, IEspecialidadeRepository
    {
        public EspecialidadeRepository(AgendaMedicaDbContext context)
            : base(context)
        {

        }
    }
}
