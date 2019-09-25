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
        private readonly IUsuarioPacienteRepository _usuarioPacienteRepository;

        public ConsultaService(IConsultaRepository consultaRepository,
            IUsuarioProfissionalRepository usuarioProfissionalRepository,
            IUsuarioPacienteRepository usuarioPacienteRepository)
            : base(consultaRepository)
        {
            _usuarioProfissionalRepository = usuarioProfissionalRepository;
            _usuarioPacienteRepository = usuarioPacienteRepository;
        }

        public override void Add(Consulta consulta)
        {
            consulta.Profissional = _usuarioProfissionalRepository.GetAll()
                .Where(x => x.Id == consulta.ProfissionalId)
                .Include(x => x.Agendas)
                    .ThenInclude(x => x.Horarios)
                .Include(x => x.Consultas)
                .SingleOrDefault();

            consulta.Paciente = _usuarioPacienteRepository.GetAll()
                .Where(x => x.Id == consulta.PacienteId)
                .Include(x => x.Consultas)
                .SingleOrDefault();

            consulta.ValidationResult = new ConsultaValidator().Validate(consulta);

            if (consulta.ValidationResult.IsValid)
                base.Add(consulta);
        }
    }
}
