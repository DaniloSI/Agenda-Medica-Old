using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces.Domain;
using AgendaMedica.Domain.Interfaces.Repositories;

namespace AgendaMedica.Domain.Services
{
    public class EspecialidadeService : Service<Especialidade>, IEspecialidadeService
    {
        public EspecialidadeService(IEspecialidadeRepository especialidadeRepository)
            : base(especialidadeRepository)
        {
        }
    }
}
