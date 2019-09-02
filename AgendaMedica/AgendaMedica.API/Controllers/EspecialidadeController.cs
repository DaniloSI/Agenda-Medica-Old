using AgendaMedica.Application.Interfaces;
using AgendaMedica.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMedica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeAppService _especialidadeAppService;

        public EspecialidadeController(IEspecialidadeAppService especialidadeAppService)
        {
            _especialidadeAppService = especialidadeAppService;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<EspecialidadeViewModel> Form(EspecialidadeViewModel especialidade)
        {
            _especialidadeAppService.Add(especialidade);
            return especialidade;
        }
    }
}
