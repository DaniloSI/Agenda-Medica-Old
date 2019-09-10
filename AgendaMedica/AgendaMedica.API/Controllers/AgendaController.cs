using AgendaMedica.Application.Interfaces;
using AgendaMedica.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    }
}
