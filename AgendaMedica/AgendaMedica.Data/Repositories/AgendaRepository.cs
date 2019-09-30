using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaMedica.Data.Repositories
{
    public class AgendaRepository : Repository<Agenda>, IAgendaRepository
    {
        public AgendaRepository(AgendaMedicaDbContext context)
            : base(context)
        {

        }

        public override void Update(Agenda obj)
        {
            IEnumerable<Horario> horarios = DbSet
                .AsNoTracking()
                .Include(agenda => agenda.Horarios)
                .Single(agenda => agenda.AgendaId == obj.AgendaId)
                .Horarios ?? new List<Horario>();

            UpdateHorarios(horarios, obj.Horarios ?? new List<Horario>());

            base.Update(obj);
        }

        private void UpdateHorarios(IEnumerable<Horario> horariosAntigos, ICollection<Horario> horariosNovos)
        {
            IEnumerable<Horario> deletar = horariosAntigos.Except(horariosNovos);
            IEnumerable<Horario> adicionar = horariosNovos.Except(horariosAntigos);

            horariosAntigos?
                .Except(horariosNovos)?
                .ToList()?
                .ForEach(horario => Db.Entry(horario).State = EntityState.Deleted);

            horariosNovos?
                .Except(horariosAntigos)?
                .ToList()?
                .ForEach(horario => Db.Entry(horario).State = EntityState.Added);
        }

        public void AddHorarioExcecao(HorarioExcecao horarioExcecao)
        {
            Db.HorariosExcecoes.Add(horarioExcecao);
        }
    }
}
