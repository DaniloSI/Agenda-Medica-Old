using AgendaMedica.Domain.Entities;

namespace AgendaMedica.Domain.Interfaces.Repositories
{
    public interface IAgendaRepository : IRepository<Agenda>
    {
        void AddHorarioExcecao(HorarioExcecao horarioExcecao);
    }
}
