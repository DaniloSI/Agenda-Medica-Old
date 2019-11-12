using AgendaMedica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AgendaMedica.Application.ViewModels.PesquisaViewModels
{
    public class BuscaProfissionaisViewModel
    {
        public string Nome { get; set; }
        public int[] EspecialidadesIds { get; set; }

        public Expression<Func<UsuarioProfissional, bool>> Filtro()
        {
            if (Nome == null)
                Nome = string.Empty;

            if (EspecialidadesIds == null)
                EspecialidadesIds = new int[] { };

            return (p) =>
            (
                (p.Nome.Contains(Nome) || Nome.Contains(p.Nome)) &&
                (EspecialidadesIds.Length == 0 || EspecialidadesIds.Any(especialidadeId => p.Especialidades.Any(e => e.EspecialidadeId == especialidadeId)))
            );
        }
    }
}
