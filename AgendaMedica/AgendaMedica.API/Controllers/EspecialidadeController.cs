using AgendaMedica.Application.Interfaces;
using AgendaMedica.Application.ViewModels;
using AgendaMedica.Domain.Interfaces.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AgendaMedica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeAppService _especialidadeAppService;
        private readonly IEspecialidadeService _especialidadeService;

        public EspecialidadeController(IEspecialidadeAppService especialidadeAppService
            , IEspecialidadeService especialidadeService)
        {
            _especialidadeAppService = especialidadeAppService;
            _especialidadeService = especialidadeService;
        }

        [HttpPost]
        [Authorize]
        public ActionResult<EspecialidadeViewModel> Form(EspecialidadeViewModel especialidade)
        {
            _especialidadeAppService.Add(especialidade);
            return especialidade;
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetEspecialidades()
        {
            return new JsonResult(
                _especialidadeService.GetAll()
                    .ToList()
                    .Select(e => new
                    {
                        e.EspecialidadeId,
                        e.Nome,
                        e.Codigo
                    })
                    .ToArray()
            );
        }
    }
}
