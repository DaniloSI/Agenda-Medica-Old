using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AgendaMedica.Data.Repositories
{
    public class UsuarioPacienteRepository : Repository<UsuarioPaciente>, IUsuarioPacienteRepository
    {
        public UsuarioPacienteRepository(AgendaMedicaDbContext context)
            : base(context)
        {

        }
    }
}
