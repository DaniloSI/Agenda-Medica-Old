using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces.Domain;
using AgendaMedica.Domain.Interfaces.Repositories;
using AgendaMedica.Domain.Validations;

namespace AgendaMedica.Domain.Services
{
    public class EspecialidadeService : Service<Especialidade>, IEspecialidadeService
    {
        public EspecialidadeService(IEspecialidadeRepository especialidadeRepository)
            : base(especialidadeRepository)
        {
        }

        public override void Add(Especialidade especialidade)
        {
            especialidade.ValidationResult = new EspecialidadeValidator().Validate(especialidade);

            if (especialidade.ValidationResult.IsValid)
                base.Add(especialidade);
        }

        public override void Update(Especialidade especialidade)
        {
            especialidade.ValidationResult = new EspecialidadeValidator().Validate(especialidade);

            if (especialidade.ValidationResult.IsValid)
                base.Update(especialidade);
        }
    }
}
