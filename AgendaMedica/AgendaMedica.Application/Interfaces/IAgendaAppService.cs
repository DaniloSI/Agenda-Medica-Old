using AgendaMedica.Application.ViewModels;

namespace AgendaMedica.Application.Interfaces
{
    public interface IAgendaAppService : IAppService<AgendaViewModel>
    {
        void AddHorarioExcecao(HorarioExcecaoViewModel horarioExcecaoViewModel);
    }
}
