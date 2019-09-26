using AgendaMedica.Application.ViewModels;
using System.Collections.Generic;

namespace AgendaMedica.Application.Interfaces
{
    public interface IConsultaAppService : IAppService<ConsultaViewModel>
    {
        IEnumerable<ConsultaViewModel> GetAllByPaciente(int id);
        IEnumerable<ConsultaViewModel> GetAllByProfissional(int id);
    }
}
