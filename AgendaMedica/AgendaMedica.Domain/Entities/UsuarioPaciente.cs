using System.Collections.Generic;

namespace AgendaMedica.Domain.Entities
{
    public class UsuarioPaciente : Usuario
    {
        public string Cpf { get; set; }
        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}
