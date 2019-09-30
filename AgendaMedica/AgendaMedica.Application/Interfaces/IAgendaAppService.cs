using AgendaMedica.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AgendaMedica.Application.Interfaces
{
    public interface IAgendaAppService : IAppService<AgendaViewModel>
    {
        void AddHorarioExcecao(HorarioExcecaoViewModel horarioExcecaoViewModel);
        IEnumerable<HorarioViewModel> GetHorariosPorDataProfissional(int profissionalId, DateTime data);
        IEnumerable<AgendaViewModel> GetList(int id);
        AgendaViewModel GetByIdToForm(int agendaId);
    }
}
