using AgendaMedica.Application.Interfaces;
using AgendaMedica.Application.ViewModels;
using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces.Domain;
using AgendaMedica.Domain.Interfaces.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaMedica.Application.AppServices
{
    public class AgendaAppService : AppService<Agenda, AgendaViewModel>, IAgendaAppService
    {
        private readonly IAgendaService _agendaService;
        private readonly IAgendaRepository _agendaRepository;
        private readonly IUsuarioProfissionalRepository _usuarioProfissionalRepository;
        public AgendaAppService(IAgendaService agendaService,
            IAgendaRepository agendaRepository,
            IUsuarioProfissionalRepository usuarioProfissionalRepository,
            IUnitOfWork UoW,
            IMapper mapper)
            : base(agendaService, UoW, mapper)
        {
            _agendaService = agendaService;
            _agendaRepository = agendaRepository;
            _usuarioProfissionalRepository = usuarioProfissionalRepository;
        }

        public override void Add(AgendaViewModel agendaViewModel)
        {
            Agenda agenda = _mapper.Map<Agenda>(agendaViewModel);

            agenda.Profissional = _usuarioProfissionalRepository.GetAll()
                .AsNoTracking()
                .Include(p => p.Agendas)
                .Single(p => p.Id == agenda.ProfissionalId);

            _agendaService.Add(agenda);

            if (agenda.ValidationResult.IsValid)
                UoW.Commit();

            agendaViewModel.ValidationResult = agenda.ValidationResult;
        }

        public override void Update(AgendaViewModel agendaViewModel)
        {
            Agenda agenda = _mapper.Map<Agenda>(agendaViewModel);

            agenda.Profissional = _usuarioProfissionalRepository.GetAll()
                .AsNoTracking()
                .Include(p => p.Agendas)
                .Single(p => p.Id == agenda.ProfissionalId);

            _agendaService.Update(agenda);

            if (agenda.ValidationResult.IsValid)
                UoW.Commit();

            agendaViewModel.ValidationResult = agenda.ValidationResult;
        }

        public void AddHorarioExcecao(HorarioExcecaoViewModel horarioExcecaoViewModel)
        {
            HorarioExcecao horarioExcecao = _mapper.Map<HorarioExcecao>(horarioExcecaoViewModel);

            _agendaService.AddHorarioExcecao(horarioExcecao);

            if (horarioExcecao.ValidationResult.IsValid)
                UoW.Commit();

            horarioExcecaoViewModel.ValidationResult = horarioExcecao.ValidationResult;
        }

        public IEnumerable<HorarioViewModel> GetHorariosPorDataProfissional(int profissionalId, DateTime data)
        {
            UsuarioProfissional profissional = _usuarioProfissionalRepository.GetAll()
                .Where(x => x.Id == profissionalId)
                .Include(x => x.Agendas)
                    .ThenInclude(x => x.Horarios)
                .SingleOrDefault();

            IEnumerable<Horario> horarios = _agendaService.GetHorariosPorDataProfissional(profissional, data)?.ToList() ?? new List<Horario>();

            return _mapper.Map<IEnumerable<HorarioViewModel>>(horarios);
        }

        public IEnumerable<AgendaViewModel> GetList(int id)
        {
            return _agendaService.GetAll()
                .Where(a => a.ProfissionalId == id)
                .Select(a => new AgendaViewModel
                {
                    AgendaId = a.AgendaId,
                    Titulo = a.Titulo,
                    DataHoraInicio = a.DataHoraInicio,
                    DataHoraFim = a.DataHoraFim,
                    ProfissionalId = a.ProfissionalId
                }).ToList();
        }

        public AgendaViewModel GetByIdToForm(int agendaId)
        {
            return _mapper.Map<AgendaViewModel>(_agendaRepository.GetAll()
                .Where(a => a.AgendaId == agendaId)
                .Include(a => a.Horarios)
                .Single());
        }
    }
}
