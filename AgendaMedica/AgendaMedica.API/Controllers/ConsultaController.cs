using AgendaMedica.Application.Interfaces;
using AgendaMedica.Application.ViewModels;
using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Identity;
using AgendaMedica.Domain.Interfaces.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaMedica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaAppService _consultaAppService;
        private readonly IConsultaService _consultaService;
        private readonly UserManager<AppUser> _userManager;

        public ConsultaController(IConsultaAppService consultaAppService,
            IConsultaService consultaService,
            UserManager<AppUser> userManager)
        {
            _consultaAppService = consultaAppService;
            _consultaService = consultaService;
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
                    c.PagamentoConfirmado,
                    c.HoraInicio,
                    c.HoraFim,
                    c.Estado
                })
            );
        }

        [HttpGet("ConfirmarPagamento")]
        [Authorize]
        public async Task<JsonResult> ConfirmarPagamento(int consultaId)
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            ConsultaViewModel consulta = _consultaAppService.GetByIdAsNoTracking(consultaId);

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
                consulta.PagamentoConfirmado = true;
                _consultaAppService.Update(consulta);
                return new JsonResult(new
                {
                    consulta.Data,
                    consulta.HoraInicio,
                    consulta.HoraFim,
                    consulta.EspecialidadeId,
                    consulta.ProfissionalId,
                    consulta.Estado,
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

        [HttpGet("ConsultasProfissional")]
        [Authorize]
        public async Task<JsonResult> GetConsultasProfissional()
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var consultas = _consultaAppService.GetAllByProfissional(user.Id);

            return new JsonResult(
                consultas.Select(c => new
                {
                    c.ConsultaId,
                    EspecialidadeNome = c.Especialidade.Nome,
                    PacienteNome = $"{c.Paciente.Nome} {c.Paciente.SobreNome}",
                    c.Paciente.Cpf,
                    c.Paciente.Email,
                    c.Paciente.PhoneNumber,
                    Data = c.Data.Date.ToString("dd/MM/yyyy"),
                    c.PagamentoConfirmado,
                    c.HoraInicio,
                    c.HoraFim,
                    DataHoraInicio = $"{c.Data.Date.ToString("yyyy-MM-dd")}T{c.HoraInicio}",
                    DataHoraFim = $"{c.Data.Date.ToString("yyyy-MM-dd")}T{c.HoraFim}",
                    c.Estado
                })
            );
        }

        [HttpGet("CancelarConsulta")]
        [Authorize]
        public async Task<JsonResult> CancelarConsulta(int consultaId)
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            ConsultaViewModel consulta = _consultaAppService.GetByIdAsNoTracking(consultaId);

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
                consulta.Estado = ConsultaEstado.Cancelada;
                _consultaAppService.Update(consulta);
                return new JsonResult(new
                {
                    consulta.Data,
                    consulta.HoraInicio,
                    consulta.HoraFim,
                    consulta.EspecialidadeId,
                    consulta.ProfissionalId,
                    consulta.Estado,
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

        [HttpGet("RealizarConsulta")]
        [Authorize]
        public async Task<JsonResult> RealizarConsulta(int consultaId)
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            ConsultaViewModel consulta = _consultaAppService.GetByIdAsNoTracking(consultaId);

            if (user.Id != consulta.ProfissionalId)
            {
                return new JsonResult(new
                {
                    ValidationResult = new
                    {
                        IsValid = false,
                        Errors = new object[] {
                            new
                            {
                                ErrorMessage = "Somente o profissional pode marcar a consulta como 'Realizada'"
                            }
                        }
                    }
                });
            }
            else
            {
                consulta.Estado = ConsultaEstado.Realizada;
                _consultaAppService.Update(consulta);
                return new JsonResult(new
                {
                    consulta.Data,
                    consulta.HoraInicio,
                    consulta.HoraFim,
                    consulta.EspecialidadeId,
                    consulta.ProfissionalId,
                    consulta.Estado,
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

        [HttpGet("RelatorioConsultasAno")]
        [Authorize]
        public async Task<JsonResult> RelatorioConsultasAno(int ano)
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var relatorioConsultas = _consultaService.RelatorioConsultas(user.Id, ano);

            return new JsonResult(relatorioConsultas);
        }

        [HttpGet("RelatorioConsultasMes")]
        [Authorize]
        public async Task<JsonResult> RelatorioConsultasMes(int ano, int mes)
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var relatorioConsultas = _consultaService.RelatorioConsultas(user.Id, ano, mes);

            return new JsonResult(relatorioConsultas);
        }
    }
}
