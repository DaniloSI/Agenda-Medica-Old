using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMedica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;
        private readonly IUnitOfWork UoW;

        public EspecialidadeController(IEspecialidadeRepository especialidadeRepository, IUnitOfWork UoW)
        {
            _especialidadeRepository = especialidadeRepository;
            this.UoW = UoW;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<Especialidade> Form(Especialidade especialidade)
        {
            _especialidadeRepository.Add(especialidade);
            UoW.Commit();

            return especialidade;
        }
    }
}
