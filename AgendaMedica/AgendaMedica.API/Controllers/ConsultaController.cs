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

        [HttpGet("ConsultasPaciente")]
        [Authorize]
        public async Task<JsonResult> GetConsultasPaciente()
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var consultas = _consultaAppService.GetAllByPaciente(user.Id);

            return new JsonResult(
                consultas.Select(c => new
                {
                    c.ConsultaId,
                    EspecialidadeNome = c.Especialidade.Nome,
                    ProfissionalNome = c.Profissional.Nome,
                    Endereco = c.Profissional.Endereco?.ToString(),
                    Data = c.Data.Date.ToString("dd/MM/yyyy"),
                    c.HoraInicio,
                    c.HoraFim
                })
            );
        }

        [HttpGet("CancelarConsulta")]
        [Authorize]
        public async Task<JsonResult> CancelarConsulta(int consultaId)
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            ConsultaViewModel consulta = _consultaAppService.GetById(consultaId);

            if (user.Id != consulta.ProfissionalId && user.Id != consulta.PacienteId)
            {
                return new JsonResult(new
                {
                    ValidationResult = new
                    {
                        IsValid = false,
                        Errors = new object[] {
                            new
                            {
                                ErrorMessage = "Somente o paciente e o profissional pode cancelar a consulta"
                            }
                        }
                    }
                });
            }
            else
            {
                _consultaAppService.Remove(consultaId);

                return new JsonResult(new
                {
                    ValidationResult = new
                    {
                        IsValid = true,
                        Errors = new object[] { }
                    }
                });
            }
        }
    }
}
