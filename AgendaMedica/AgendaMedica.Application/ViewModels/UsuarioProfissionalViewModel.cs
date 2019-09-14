using FluentValidation.Results;
using System.Collections.Generic;

namespace AgendaMedica.Application.ViewModels
{
    public class UsuarioProfissionalViewModel : UsuarioViewModel
    {
        public string Cnpj { get; set; }
        public string Orgao { get; set; }
        public string Estado { get; set; }
        public string Registro { get; set; }
        public IEnumerable<EspecialidadeViewModel> Especialidades { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
