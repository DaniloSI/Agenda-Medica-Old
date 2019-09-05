using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces.Domain;
using AgendaMedica.Domain.Interfaces.Repositories;
using AgendaMedica.Domain.Validations;

namespace AgendaMedica.Domain.Services
{
    public class ConsultaService : Service<Consulta>, IConsultaService
    {
        public ConsultaService(IConsultaRepository consultaRepository)
            : base(consultaRepository)
        {
        }

        public override void Add(Consulta consulta)
        {
            consulta.ValidationResult = new ConsultaValidator().Validate(consulta);

            if (consulta.ValidationResult.IsValid)
                base.Add(consulta);
        }
    }
}
