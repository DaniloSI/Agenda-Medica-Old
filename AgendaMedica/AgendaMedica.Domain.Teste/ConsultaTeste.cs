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
    public class ConsultaValidatorTeste
    {
        private Consulta consulta;
        private IConsultaService _consultaService;


        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            consulta = new Consulta
            {
                ConsultaId = 0,
                PagamentoConfirmado = false,
                Data = DateTime.Today,
                HoraInicio = DateTime.Now.AddHours(-3).TimeOfDay,
                HoraFim = DateTime.Now.AddHours(-2).TimeOfDay,
                EspecialidadeId = 1,
                Especialidade = new Especialidade
                {
                    EspecialidadeId = 1,
                    Codigo = "CG",
                    Nome = "Clínico Geral"
                },
                PacienteId = 1,
                Paciente = new UsuarioPaciente
                {
                    Id = 1,
                    Nome = "Danilo",
                    SobreNome = "de Oliveira",
                    DataNascimento = new DateTime(1994, 11, 29, 14, 30, 0),
                    Cpf = "123.456.789-10",
                    Email = "danilo@teste.com",
                    UserName = "danilo@teste.com",
                    EnderecoId = 2,
                    Endereco = new Endereco
                    {
                        EnderecoId = 2,
                        CEP = "12345-679",
                        Cidade = "Vitória",
                        Estado = "Espírito Santo",
                        Numero = 12,
                        Rua = "Rua das Gaivotas"
                    }
                },
                ProfissionalId = 2,
                Profissional = new UsuarioProfissional
                {
                    Id = 2,
                    Nome = "Fulano",
                    SobreNome = "de Tal",
                    DataNascimento = new DateTime(1984, 11, 15, 07, 18, 0),
                    Cnpj = "321.654.987-01",
                    Email = "fulano.tal@teste.com",
                    UserName = "fulano.tal@teste.com",
                    Orgao = "Conselho Federal de Medicina",
                    Estado = "ES",
                    Registro = "457261",
                    EnderecoId = 2,
                    Endereco = new Endereco
                    {
                        EnderecoId = 2,
                        CEP = "54321-876",
                        Cidade = "Vitória",
                        Estado = "Espírito Santo",
                        Numero = 7,
                        Rua = "Rua dos Afrás"
                    },
                    Agendas = new List<Agenda>
                    {
                        new Agenda
                        {
                            Horarios = new List<Horario>()
                        }
                    }
                }
            };

            var mock = new Mock<IConsultaRepository>();
            var mockProfissional = new Mock<IUsuarioProfissionalRepository>();
            var mockPaciente = new Mock<IUsuarioPacienteRepository>();
            mock.Setup(x => x.Add(It.IsAny<Consulta>()));
            mockProfissional.Setup(x => x.GetAll()).Returns(new List<UsuarioProfissional> { consulta.Profissional }.AsQueryable());
            mockPaciente.Setup(x => x.GetAll()).Returns(new List<UsuarioPaciente> { consulta.Paciente }.AsQueryable());
            _consultaService = new ConsultaService(mock.Object, mockProfissional.Object, mockPaciente.Object);
        }

        [Test]
        [Category("Agendar Consulta")]
        public void ConsultaNaoPodeSerNoPassado()
        {
            consulta.Data = DateTime.Today.AddDays(-5);
            consulta.HoraInicio = DateTime.Today.AddDays(-5).AddHours(-3).TimeOfDay;
            consulta.HoraFim = DateTime.Today.AddDays(-5).AddHours(-2).TimeOfDay;

            _consultaService.Add(consulta);
            Assert.IsNotEmpty(consulta.ValidationResult.Errors.Where(e => e.ErrorMessage == ConsultaValidator.ErrorsMessages["CONSULTA_NO_PASSADO"]));
        }

        [Test]
        [Category("Agendar Consulta")]
        public void ConsultaNaoPodeConflitarHorarioProfissional()
        {
            DateTime dataInicioConsulta = new DateTime(2019, 09, 06, 15, 30, 00);
            DateTime dataFimConsulta = new DateTime(2019, 09, 06, 16, 30, 00);

            consulta.Data = dataInicioConsulta.Date;
            consulta.HoraInicio = dataInicioConsulta.TimeOfDay;
            consulta.HoraFim = dataFimConsulta.TimeOfDay;

            consulta.Profissional.Consultas = new List<Consulta>
            {
                new Consulta
                {
                    ConsultaId = 1,
                    PagamentoConfirmado = true,
                    Data = dataInicioConsulta.Date,
                    HoraInicio = dataInicioConsulta.AddMinutes(30).TimeOfDay,
                    HoraFim = dataFimConsulta.AddMinutes(30).TimeOfDay,
                    ProfissionalId = 2
                }
            };

            _consultaService.Add(consulta);
            Assert.IsNotEmpty(consulta.ValidationResult.Errors.Where(e => e.ErrorMessage == ConsultaValidator.ErrorsMessages["CONFLITO_HORARIO_PROFISSIONAL"].Replace("{{PROFISSIONAL_NOME}}", consulta.Profissional.Nome)));
        }

        [Test]
        [Category("Agendar Consulta")]
        public void HorarioDeveEstarDisponivelNaAgenda()
        {
            consulta.Data = new DateTime(2019, 9, 24);
            consulta.HoraInicio = new TimeSpan(8, 30, 0);
            consulta.HoraFim = new TimeSpan(9, 30, 0);

            consulta.Profissional.Agendas = new List<Agenda>
            {
                new Agenda
                {
                    AgendaId = 1,
                    DataHoraInicio = DateTime.MinValue,
                    DataHoraFim = DateTime.MaxValue,
                    ProfissionalId = consulta.ProfissionalId,
                    Horarios = new List<Horario>
                    {
                        new Horario
                        {
                            HorarioId = 1,
                            AgendaId = 1,
                            DiaSemana = DiaSemana.Terca,
                            HoraInicio = new TimeSpan(13, 30, 0),
                            HoraFim = new TimeSpan(14, 30, 0)
                        },
                        new Horario
                        {
                            HorarioId = 2,
                            AgendaId = 1,
                            DiaSemana = DiaSemana.Terca,
                            HoraInicio = new TimeSpan(14, 30, 0),
                            HoraFim = new TimeSpan(15, 30, 0)
                        }
                    }
                }
            };

            _consultaService.Add(consulta);
            Assert.IsNotEmpty(consulta.ValidationResult.Errors.Where(e => e.ErrorMessage == ConsultaValidator.ErrorsMessages["HORARIO_INDISPONIVEL"]));
        }

        [Test]
        [Category("Agendar Consulta")]
        public void ConsultaNaoPodeConflitarHorarioPaciente()
        {
            DateTime dataInicioConsulta = new DateTime(2019, 09, 06, 15, 30, 00);
            DateTime dataFimConsulta = new DateTime(2019, 09, 06, 16, 30, 00);

            consulta.Data = dataInicioConsulta.Date;
            consulta.HoraInicio = dataInicioConsulta.TimeOfDay;
            consulta.HoraFim = dataFimConsulta.TimeOfDay;

            consulta.Paciente.Consultas = new List<Consulta>
            {
                new Consulta
                {
                    ConsultaId = 1,
                    PagamentoConfirmado = true,
                    Data = dataInicioConsulta.Date,
                    HoraInicio = dataInicioConsulta.AddMinutes(30).TimeOfDay,
                    HoraFim = dataFimConsulta.AddMinutes(30).TimeOfDay,
                    ProfissionalId = 2,
                    PacienteId = 1
                }
            };

            _consultaService.Add(consulta);
            Assert.IsNotEmpty(consulta.ValidationResult.Errors.Where(e => e.ErrorMessage == ConsultaValidator.ErrorsMessages["CONFLITO_HORARIO_PACIENTE"]));
        }
    }
}
