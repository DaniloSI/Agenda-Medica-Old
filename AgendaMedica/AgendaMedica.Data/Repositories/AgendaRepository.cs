using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces.Repositories;

namespace AgendaMedica.Data.Repositories
{
    public class AgendaRepository : Repository<Agenda>, IAgendaRepository
    {
        public AgendaRepository(AgendaMedicaDbContext context)
            : base(context)
        {

        }
    }
}
