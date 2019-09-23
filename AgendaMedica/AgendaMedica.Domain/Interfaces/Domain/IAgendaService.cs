using AgendaMedica.Domain.Entities;
using System;
using System.Collections.Generic;

namespace AgendaMedica.Domain.Interfaces.Domain
{
    public interface IAgendaService : IService<Agenda>
    {
        void AddHorarioExcecao(HorarioExcecao horarioExcecao);

        IEnumerable<Horario> GetHorariosPorDataProfissional(UsuarioProfissional profissional, DateTime data);
    }
}
