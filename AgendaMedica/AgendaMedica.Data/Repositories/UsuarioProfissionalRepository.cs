using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AgendaMedica.Data.Repositories
{
    public class UsuarioProfissionalRepository : Repository<UsuarioProfissional>, IUsuarioProfissionalRepository
    {
        public UsuarioProfissionalRepository(AgendaMedicaDbContext context)
            : base(context)
        {

        }

        public override UsuarioProfissional GetById(int id)
        {
            var usuarioProfissional = DbSet.Include(x => x.Especialidades).SingleOrDefault(x => x.Id == id);

            foreach (var especialidade in usuarioProfissional.Especialidades)
            {
                especialidade.Especialidade = Db.Especialidades.Find(especialidade.EspecialidadeId);
            }

            return usuarioProfissional;
        }
    }
}
