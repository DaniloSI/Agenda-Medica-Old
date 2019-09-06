using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces.Domain;
using AgendaMedica.Domain.Interfaces.Repositories;
using AgendaMedica.Domain.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AgendaMedica.Domain.Teste
{
    [TestFixture]
    public class ConsultaValidatorTeste
    {
        private Consulta consulta;
        private IConsultaService _consultaService;

        [SetUp]
        public void Setup()
        {
            consulta = new Consulta
            {
                ConsultaId = 0,
                PagamentoConfirmado = false,
                Data = DateTime.Today,
                HoraInicio = DateTime.Now.AddHours(-3).TimeOfDay,
                HoraFim = DateTime.Now.AddHours(-2).TimeOfDay,
                EnderecoId = 1,
                Endereco = new Endereco
                {
                    EnderecoId = 1,
                    CEP = "12345-678",
                    Cidade = "Vitória",
                    Estado = "Espírito Santo",
                    Numero = 25,
                    Rua = "Rua das Garças"
                },
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
                    }
                }
            };
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var mock = new Mock<IConsultaRepository>();
            mock.Setup(x => x.Add(It.IsAny<Consulta>()));
            _consultaService = new ConsultaService(mock.Object);
        }

        [Test]
        [Category("Agendar Consulta")]
        public void ConsultaNaoPodeSerNoPassado()
        {
            consulta.Data = DateTime.Today;
            consulta.HoraInicio = DateTime.Now.AddHours(-3).TimeOfDay;
            consulta.HoraFim = DateTime.Now.AddHours(-2).TimeOfDay;

            _consultaService.Add(consulta);
            Assert.IsFalse(consulta.ValidationResult.IsValid);
        }

        [Test]
        [Category("Agendar Consulta")]
        public void ConsultaNaoPodeConflitarHorarioProfissional()
        {
            DateTime dataInicioConsulta = DateTime.Now.AddHours(4).AddMinutes(6);
            DateTime dataFimConsulta = DateTime.Now.AddHours(5).AddMinutes(7);

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
            Assert.IsFalse(consulta.ValidationResult.IsValid);
        }
    }
}
