using System;

namespace AgendaMedica.API.DTO
{
    public class UsuarioPacienteDTO
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
    }
}
