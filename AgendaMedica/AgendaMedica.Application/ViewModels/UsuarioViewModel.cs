using AgendaMedica.Domain.Entities;
using System;

namespace AgendaMedica.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int? EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }
}
