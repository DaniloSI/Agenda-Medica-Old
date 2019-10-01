using System;

namespace AgendaMedica.Domain.Entities
{
    public enum DiaSemana
    {
        Domingo,
        Segunda,
        Terca,
        Quarta,
        Quinta,
        Sexta,
        Sabado
    }

    public class Horario
    {
        public int HorarioId { get; set; }
        public DiaSemana DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public int AgendaId { get; set; }
        public virtual Agenda Agenda { get; set; }

        public bool Conflita(Horario horario)
        {
            bool diaSemanaIgual = horario.DiaSemana == DiaSemana;
            bool horarioInicioConflita = horario.HoraInicio >= HoraInicio && horario.HoraInicio < HoraFim;
            bool horarioFimConflita = horario.HoraFim > HoraInicio && horario.HoraFim <= HoraFim;
            horarioInicioConflita = horarioInicioConflita || HoraInicio >= horario.HoraInicio && HoraInicio < horario.HoraFim;
            horarioFimConflita = horarioFimConflita || HoraFim > horario.HoraInicio && HoraFim <= horario.HoraFim;

            return diaSemanaIgual && (horarioInicioConflita || horarioFimConflita);
        }
    }
}
