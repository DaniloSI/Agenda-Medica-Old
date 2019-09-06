using AgendaMedica.Domain.Entities.ManyToManys;
using System.Collections.Generic;
using System.Linq;

namespace AgendaMedica.Domain.Entities
{
    public class UsuarioProfissional : Usuario
    {
        public string Cnpj { get; set; }
        public string Orgao { get; set; }
        public string Estado { get; set; }
        public string Registro { get; set; }
        public virtual ICollection<UsuarioProfissionalEspecialidade> Especialidades { get; set; }
        public virtual ICollection<Consulta> Consultas { get; set; }

        public bool ConflitaHorario(Consulta novaConsulta)
        {
            return Consultas == null || Consultas.Any(consulta =>
            {
                bool conflitaHorarioInicio = novaConsulta.DataHoraInicio >= consulta.DataHoraInicio && novaConsulta.DataHoraInicio <= consulta.DataHoraFim;
                bool conflitaHorarioFim = novaConsulta.DataHoraFim >= consulta.DataHoraInicio && novaConsulta.DataHoraFim <= consulta.DataHoraFim;

                return conflitaHorarioInicio || conflitaHorarioFim;
            });
        }
    }
}
