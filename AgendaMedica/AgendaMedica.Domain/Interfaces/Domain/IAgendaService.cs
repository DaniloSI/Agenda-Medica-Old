using AgendaMedica.Domain.Entities;

namespace AgendaMedica.Domain.Interfaces.Domain
{
    public interface IAgendaService : IService<Agenda>
    {
        void AddHorarioExcecao(HorarioExcecao horarioExcecao);
    }
}
