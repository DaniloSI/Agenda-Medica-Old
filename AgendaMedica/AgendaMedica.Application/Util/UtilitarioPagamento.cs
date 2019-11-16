using AgendaMedica.Application.ViewModels;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaMedica.Application.Util
{
    public class PagamentoStatus
    {
        public bool Realizado { get; set; }
        public string[] ErrosMensagens { get; set; }
    }

    public class PagamentoValidation : AbstractValidator<PagamentoStatus>
    {
        public PagamentoValidation()
        {
            RuleFor(pagamentoStatus => pagamentoStatus)
                .Must(pagamentoStatus => pagamentoStatus.Realizado)
                .WithMessage(pagamentoStatus => string.Join('\n', pagamentoStatus.ErrosMensagens));
        }
    }

    public class UtilitarioPagamento
    {
        public static ValidationResult RealizarPagamentoCredito(CartaoViewModel cartao)
        {
            PagamentoStatus pagamentoStatus = new PagamentoStatus
            {
                Realizado = true
            };

            return new PagamentoValidation().Validate(pagamentoStatus);
        }
    }
}
