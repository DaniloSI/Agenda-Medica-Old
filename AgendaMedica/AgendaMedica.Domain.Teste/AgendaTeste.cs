using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces.Domain;
using AgendaMedica.Domain.Interfaces.Repositories;
using AgendaMedica.Domain.Services;
using AgendaMedica.Domain.Validations;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaMedica.Domain.Teste
{
    [TestFixture]
    public class AgendaTeste
    {
        private Agenda agenda;
        private IAgendaService _agendaService;

        [SetUp]
        public void Setup()
        {
            agenda = new Agenda
            {
                AgendaId = 0,
                DataHoraInicio = new DateTime(2019, 05, 17, 14, 30, 0),
                DataHoraFim = new DateTime(2019, 10, 17, 14, 30, 0),
                Horarios = new List<Horario>
                {
                    new Horario
                    {
                        HorarioId = 1,
                        DiaSemana = DiaSemana.Segunda,
                        HoraInicio = new TimeSpan(7, 30, 0),
                        HoraFim = new TimeSpan(8, 30, 0)
                    },
                    new Horario
                    {
                        HorarioId = 2,
                        DiaSemana = DiaSemana.Segunda,
                        HoraInicio = new TimeSpan(8, 0, 0),
                        HoraFim = new TimeSpan(9, 0, 0)
                    }
                },
                ProfissionalId = 1
            };

            agenda.Profissional = new UsuarioProfissional
            {
                Id = 1,
                Nome = "Fulano",
                SobreNome = "de Tal",
                Email = "fulano@teste.com",
                Agendas = new List<Agenda> { agenda }
            };
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var mock = new Mock<IAgendaRepository>();
            mock.Setup(x => x.Add(It.IsAny<Agenda>()));
            _agendaService = new AgendaService(mock.Object);
        }

        [Test]
        [Category("Cadastrar nova Agenda")]
        public void AgendaDataInicioMenorQueDataFim()
        {
            agenda.DataHoraInicio = new DateTime(2019, 10, 17, 14, 30, 0);
            agenda.DataHoraFim = new DateTime(2019, 05, 17, 14, 30, 0);
            _agendaService.Add(agenda);
            Assert.IsNotEmpty(agenda.ValidationResult.Errors.Where(e => e.ErrorMessage == AgendaValidator.ErrorsMessages["DATA_FIM_MAIOR_QUE_DATA_INICIO"]));
        }

        [Test]
        [Category("Cadastrar nova Agenda")]
        public void NaoDeveConflitarPeriodoVigencia()
        {
            agenda.Profissional.Agendas.Add(new Agenda
            {
                AgendaId = 2,
                ProfissionalId = 1,
                DataHoraInicio = agenda.DataHoraInicio.AddDays(1),
                DataHoraFim = agenda.DataHoraFim.AddDays(1)
            });

            _agendaService.Add(agenda);
            Assert.IsNotEmpty(agenda.ValidationResult.Errors.Where(e => e.ErrorMessage == AgendaValidator.ErrorsMessages["CONFLITO_PERIODO_VIGENCIA"]));
        }

        [Test]
        [Category("Adicionar horário(s) à Agenda")]
        public void NaoDeveHaverConflitosDeHorarios()
        {
            _agendaService.Add(agenda);
            Assert.IsNotEmpty(agenda.ValidationResult.Errors.Where(e => e.ErrorMessage == AgendaValidator.ErrorsMessages["HORARIOS_CONFLITAM"]));
        }

        [Test]
        [Category("Adicionar horário(s) à Agenda")]
        public void ObterHorariosPorData()
        {
            Assert.AreEqual(_agendaService.GetHorariosPorDataProfissional(agenda.Profissional, new DateTime(2019, 07, 15)).Count(h => h.HorarioId == 1 || h.HorarioId == 2), 2);
        }
    }
}
