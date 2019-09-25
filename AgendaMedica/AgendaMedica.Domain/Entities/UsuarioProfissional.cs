using AgendaMedica.Domain.Entities.ManyToManys;
using System.Collections.Generic;

namespace AgendaMedica.Domain.Entities
{
    public class UsuarioProfissional : Usuario
    {
        public string Cnpj { get; set; }
        public string Orgao { get; set; }
        public string Estado { get; set; }
        public string Registro { get; set; }
        public virtual ICollection<UsuarioProfissionalEspecialidade> Especialidades { get; set; }

        public virtual ICollection<Agenda> Agendas { get; set; }
    }
}
