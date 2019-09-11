using AgendaMedica.Domain.Entities;
using FluentValidation;
using System.Collections.Generic;

namespace AgendaMedica.Domain.Validations
{
    public class EspecialidadeValidator : AbstractValidator<Especialidade>
    {
        public static readonly IReadOnlyDictionary<string, string> ErrorsMessages = new Dictionary<string, string>
        {
            ["CODIGO_VAZIO"] = "O código da Especialidade não pode ser vazio"
        };

        public EspecialidadeValidator()
        {
            RuleFor(especialidade => especialidade.Codigo).NotEmpty().WithMessage(ErrorsMessages["CODIGO_VAZIO"]);
        }
    }
}
