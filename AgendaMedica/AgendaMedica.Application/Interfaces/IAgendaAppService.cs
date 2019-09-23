using AgendaMedica.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace AgendaMedica.Application.Interfaces
{
    public interface IAgendaAppService : IAppService<AgendaViewModel>
    {
        void AddHorarioExcecao(HorarioExcecaoViewModel horarioExcecaoViewModel);
        IEnumerable<HorarioViewModel> GetHorariosPorDataProfissional(int profissionalId, DateTime data);
    }
}
