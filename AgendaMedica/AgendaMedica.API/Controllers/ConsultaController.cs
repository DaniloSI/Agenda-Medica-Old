using AgendaMedica.Application.Interfaces;
using AgendaMedica.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMedica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaAppService _consultaAppService;

        public ConsultaController(IConsultaAppService consultaAppService)
        {
            _consultaAppService = consultaAppService;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<ConsultaViewModel> Form(ConsultaViewModel consulta)
        {
            _consultaAppService.Add(consulta);
            return consulta;
        }
    }
}
