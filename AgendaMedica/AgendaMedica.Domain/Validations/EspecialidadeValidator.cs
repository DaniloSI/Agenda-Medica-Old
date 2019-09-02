using AgendaMedica.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaMedica.Domain.Validations
{
    public class EspecialidadeValidator : AbstractValidator<Especialidade>
    {
        public EspecialidadeValidator()
        {
            RuleFor(especialidade => especialidade.Codigo).NotEmpty().WithMessage("O código da Especialidade não pode ser vazio");
        }
    }
}
