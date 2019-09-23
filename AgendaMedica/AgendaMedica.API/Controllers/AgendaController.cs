using AgendaMedica.Application.Interfaces;
using AgendaMedica.Application.ViewModels;
using AgendaMedica.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AgendaMedica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaAppService _agendaAppService;

        public AgendaController(IAgendaAppService agendaAppService)
        {
            _agendaAppService = agendaAppService;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<AgendaViewModel> Form(AgendaViewModel agenda)
        {
            _agendaAppService.Add(agenda);
            return agenda;
        }

        [HttpPost("AddHorarioExcecao")]
        [AllowAnonymous]
        public ActionResult<HorarioExcecaoViewModel> AddHorarioExcecao(HorarioExcecaoViewModel horarioExcecao)
        {
            _agendaAppService.AddHorarioExcecao(horarioExcecao);
            return horarioExcecao;
        }

        [HttpGet("HorariosPorData")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<HorarioViewModel>> GetHorariosPorData(int profissionalId, DateTime data)
        {
            return new List<HorarioViewModel>
            {
                new HorarioViewModel
                {
                    HorarioId = 1,
                    DiaSemana = (DiaSemana) data.DayOfWeek,
                    HoraInicio = new TimeSpan(7, 30, 0),
                    HoraFim = new TimeSpan(8, 30, 0)
                },
                new HorarioViewModel
                {
                    HorarioId = 2,
                    DiaSemana = (DiaSemana) data.DayOfWeek,
                    HoraInicio = new TimeSpan(8, 30, 0),
                    HoraFim = new TimeSpan(9, 30, 0)
                },
                new HorarioViewModel
                {
                    HorarioId = 3,
                    DiaSemana = (DiaSemana) data.DayOfWeek,
                    HoraInicio = new TimeSpan(15, 30, 0),
                    HoraFim = new TimeSpan(16, 30, 0)
                }
            };
        }
    }
}
