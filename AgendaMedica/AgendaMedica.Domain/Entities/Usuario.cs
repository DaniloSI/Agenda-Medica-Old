using AgendaMedica.Domain.Identity;
using System;

namespace AgendaMedica.Domain.Entities
{
    public abstract class Usuario : AppUser
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int? EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
