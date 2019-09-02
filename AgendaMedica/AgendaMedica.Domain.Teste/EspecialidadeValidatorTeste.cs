using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Validations;
using NUnit.Framework;

namespace AgendaMedica.Domain.Teste
{
    [TestFixture]
    public class EspecialidadeValidatorTeste
    {
        private EspecialidadeValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new EspecialidadeValidator();
        }

        [Test]
        public void EspecialidadeCodigoObrigatorio()
        {
            Especialidade especialidade = new Especialidade
            {
                Codigo = string.Empty
            };

            Assert.IsFalse(validator.Validate(especialidade).IsValid);
        }
    }
}
