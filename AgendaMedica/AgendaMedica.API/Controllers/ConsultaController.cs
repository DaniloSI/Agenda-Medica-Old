using AgendaMedica.Application.Interfaces;
using AgendaMedica.Application.ViewModels;
using AgendaMedica.Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaMedica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaAppService _consultaAppService;
        private readonly UserManager<AppUser> _userManager;

        public ConsultaController(IConsultaAppService consultaAppService,
            UserManager<AppUser> userManager)
        {
            _consultaAppService = consultaAppService;
            _userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<JsonResult> Form(ConsultaViewModel consulta)
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            consulta.PacienteId = user.Id;

            _consultaAppService.Add(consulta);
            return new JsonResult(new
            {
                consulta.Data,
                consulta.HoraInicio,
                consulta.HoraFim,
                consulta.EspecialidadeId,
                consulta.ProfissionalId,
                ValidationResult = new
                {
                    consulta.ValidationResult.IsValid,
                    Errors = consulta.ValidationResult.Errors?.Select(e => new
                    {
                        e.ErrorMessage
                    })
                }
            });
        }
    }
}
