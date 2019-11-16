using System;
using System.Collections.Generic;
using System.Linq;
using AgendaMedica.Application.Interfaces;
using AgendaMedica.Application.Util;
using AgendaMedica.Application.ViewModels;
using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces.Domain;
using AgendaMedica.Domain.Interfaces.Repositories;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Application.AppServices
{
    public class ConsultaAppService : AppService<Consulta, ConsultaViewModel>, IConsultaAppService
    {
        private readonly IConsultaService _consultaService;
        private readonly IConsultaRepository _consultaRepository;
        public ConsultaAppService(IConsultaService consultaService,
            IConsultaRepository consultaRepository,
            IUnitOfWork UoW,
            IMapper mapper)
            : base(consultaService, UoW, mapper)
        {
            _consultaService = consultaService;
            _consultaRepository = consultaRepository;
        }

        public override void Add(ConsultaViewModel consultaViewModel)
        {
            Consulta consulta = _mapper.Map<Consulta>(consultaViewModel);

            _consultaService.Add(consulta);

            if (consulta.ValidationResult.IsValid)
            {
                ValidationResult resultPagamento = null;

                if (consulta.TipoPagamento == TipoPagamento.Credito)
                {
                    resultPagamento = UtilitarioPagamento.RealizarPagamentoCredito(consultaViewModel.Cartao);
                }

                if (resultPagamento?.IsValid ?? true)
                {
                    UoW.Commit();

                    if (consulta.TipoPagamento == TipoPagamento.Credito)
                    {
                        consulta.PagamentoConfirmado = true;
                        consulta.DataRealizacaoPagamento = DateTime.Now;

                        _consultaService.Update(consulta);

                        UoW.Commit();
                    }
                }
                else
                    consulta.ValidationResult = resultPagamento;
            }

            consultaViewModel.ValidationResult = consulta.ValidationResult;
        }

        public override void Update(ConsultaViewModel consultaViewModel)
        {
            Consulta consulta = _mapper.Map<Consulta>(consultaViewModel);

            _consultaService.Update(consulta);
            consulta.ValidationResult = new FluentValidation.Results.ValidationResult();

            if (consulta.ValidationResult.IsValid)
                UoW.Commit();

            consultaViewModel.ValidationResult = consulta.ValidationResult;
        }

        public override void Remove(int id)
        {
            base.Remove(id);
            UoW.Commit();
        }

        public IEnumerable<ConsultaViewModel> GetAllByPaciente(int id)
        {
            IEnumerable<Consulta> consultas = _consultaRepository
                .GetAll()
                .Include(c => c.Especialidade)
                .Include(c => c.Profissional)
                    .ThenInclude(p => p.Endereco)
                .Where(consulta => consulta.PacienteId == id)?
                .ToList() ?? new List<Consulta>();

            return _mapper.Map<IEnumerable<ConsultaViewModel>>(consultas);
        }

        public IEnumerable<ConsultaViewModel> GetAllByProfissional(int id)
        {
            IEnumerable<Consulta> consultas = _consultaRepository
                .GetAll()
                .Include(c => c.Especialidade)
                .Include(c => c.Paciente)
                .Where(consulta => consulta.ProfissionalId == id)?
                .ToList() ?? new List<Consulta>();

            return _mapper.Map<IEnumerable<ConsultaViewModel>>(consultas);
        }
    }
}
