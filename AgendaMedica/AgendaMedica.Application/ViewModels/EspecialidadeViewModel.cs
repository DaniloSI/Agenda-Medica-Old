using FluentValidation.Results;

namespace AgendaMedica.Application.ViewModels
{
    public class EspecialidadeViewModel
    {
        public int EspecialidadeId { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }

        public ValidationResult ValidationResult { get; set; }
    }
}
