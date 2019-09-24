using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces.Domain;
using AgendaMedica.Domain.Interfaces.Repositories;
using AgendaMedica.Domain.Validations;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AgendaMedica.Domain.Services
{
    public class ConsultaService : Service<Consulta>, IConsultaService
    {
        private readonly IUsuarioProfissionalRepository _usuarioProfissionalRepository;

        public ConsultaService(IConsultaRepository consultaRepository,
            IUsuarioProfissionalRepository usuarioProfissionalRepository)
            : base(consultaRepository)
        {
            _usuarioProfissionalRepository = usuarioProfissionalRepository;
        }

        public override void Add(Consulta consulta)
        {
            consulta.Profissional = _usuarioProfissionalRepository.GetAll()
                .Where(x => x.Id == consulta.ProfissionalId)
                .Include(x => x.Agendas)
                    .ThenInclude(x => x.Horarios)
                .SingleOrDefault();

            consulta.ValidationResult = new ConsultaValidator().Validate(consulta);

            if (consulta.ValidationResult.IsValid)
                base.Add(consulta);
        }
    }
}
