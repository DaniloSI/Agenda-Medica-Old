using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces.Domain;
using AgendaMedica.Domain.Interfaces.Repositories;
using AgendaMedica.Domain.Services;
using AgendaMedica.Domain.Validations;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace AgendaMedica.Domain.Teste
{
    [TestFixture]
    public class EspecialidadeTeste
    {
        private Especialidade especialidade;
        private IEspecialidadeService _especialidadeService;

        [SetUp]
        public void Setup()
        {
            especialidade = new Especialidade
            {
                EspecialidadeId = 0,
                Nome = "Clínico Geral",
                Codigo = "CG"
            };
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var mock = new Mock<IEspecialidadeRepository>();
            mock.Setup(x => x.Add(It.IsAny<Especialidade>()));
            _especialidadeService = new EspecialidadeService(mock.Object);
        }

        [Test]
        [Category("Cadastrar nova Especialidade")]
        public void EspecialidadeCodigoObrigatorio()
        {
            especialidade.Codigo = "";

            _especialidadeService.Add(especialidade);

            Assert.IsNotEmpty(especialidade.ValidationResult.Errors.Where(e => e.ErrorMessage == EspecialidadeValidator.ErrorsMessages["CODIGO_VAZIO"]));
        }
    }
}
