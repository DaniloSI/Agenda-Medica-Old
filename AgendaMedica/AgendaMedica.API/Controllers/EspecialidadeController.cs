using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces.Domain;
using AgendaMedica.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMedica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeService _especialidadeService;
        private readonly IUnitOfWork UoW;

        public EspecialidadeController(IEspecialidadeService especialidadeService, IUnitOfWork UoW)
        {
            _especialidadeService = especialidadeService;
            this.UoW = UoW;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<Especialidade> Form(Especialidade especialidade)
        {
            _especialidadeService.Add(especialidade);
            UoW.Commit();

            return especialidade;
        }
    }
}
