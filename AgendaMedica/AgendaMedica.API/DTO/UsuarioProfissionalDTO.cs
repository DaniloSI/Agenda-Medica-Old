using System;

namespace AgendaMedica.API.DTO
{
    public class UsuarioProfissionalDTO
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Orgao { get; set; }
        public string Estado { get; set; }
        public string Registro { get; set; }
    }
}
