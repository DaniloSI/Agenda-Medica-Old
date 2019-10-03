using AgendaMedica.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaMedica.Domain.Entities
{
    public abstract class Usuario : AppUser
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int? EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Consulta> Consultas { get; set; }

        public bool ConflitaHorario(Consulta novaConsulta)
        {
            return Consultas?.Any(c => c.ConflitaHorario(novaConsulta)) ?? false;
        }
    }
}
