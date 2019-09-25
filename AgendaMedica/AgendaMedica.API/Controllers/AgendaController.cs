using AgendaMedica.Application.Interfaces;
using AgendaMedica.Application.ViewModels;
using AgendaMedica.Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaMedica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaAppService _agendaAppService;
        private readonly IConsultaAppService _consultaAppService;
        private readonly UserManager<AppUser> _userManager;

        public AgendaController(IAgendaAppService agendaAppService,
            IConsultaAppService consultaAppService,
            UserManager<AppUser> userManager)
        {
            _agendaAppService = agendaAppService;
            _consultaAppService = consultaAppService;
            _userManager = userManager;
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
        public JsonResult GetHorariosPorData(int profissionalId, DateTime data)
        {
            var horarios = _agendaAppService.GetHorariosPorDataProfissional(profissionalId, data)
                .Select(x => new
                {
                    x.HorarioId,
                    x.AgendaId,
                    x.DiaSemana,
                    x.HoraInicio,
                    x.HoraFim
                });

            return new JsonResult(horarios);
        }
    }
}
