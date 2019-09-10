using System;

namespace AgendaMedica.Domain.Entities
{
    public class HorarioExcecao
    {
        public int HorarioExcecaoId { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public int ProfissionalId { get; set; }
        public virtual UsuarioProfissional Profissional { get; set; }
    }
}
