using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces.Repositories;

namespace AgendaMedica.Data.Repositories
{
    public class ConsultaRepository : Repository<Consulta>, IConsultaRepository
    {
        public ConsultaRepository(AgendaMedicaDbContext context)
            : base(context)
        {

        }
    }
}
