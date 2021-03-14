using Alunos.Validators.Alunos;
using Alunos.Domain.Requests;
using Xunit;
using FluentValidation.TestHelper;

namespace Alunos.Validators.UnitTests
{
    public class UpdateAlunoRequestValidatorUnitTest
    {
        UpdateAlunoRequestValidator _validator;
        public UpdateAlunoRequestValidatorUnitTest()
        {
            var context = FakeAppDbContext.Build();
            _validator = new UpdateAlunoRequestValidator(context);
        }

        [Fact]
        public void ShouldBeValid()
        {
            // Arrange
            var request = new UpdateAlunoRequest
            {
                AlunoId = 1,
                Nome = "Aluno Test",
                Email = "aluno@test.com"
            };

            // Act
            var result = _validator.TestValidate(request);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ShouldBeInvalidBecauseDoesNotHaveAName()
        {
            // Arrange
            var request = new UpdateAlunoRequest
            {
                Email = "aluno@test.com"
            };

            // Act
            var result = _validator.TestValidate(request);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldBeInvalidBecauseHaveANameBiggerThenMaximumLength()
        {
            // Arrange
            var request = new UpdateAlunoRequest
            {
                Nome = new string('A', 251),
                Email = "aluno@test.com"
            };

            // Act
            var result = _validator.TestValidate(request);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldBeInvalidBecauseDoesNotHaveAValidEmail()
        {
            // Arrange
            var request = new UpdateAlunoRequest
            {
                AlunoId = 1,
                Nome = "Aluno Test",
                Email = "alunotest.com"
            };

            // Act
            var result = _validator.TestValidate(request);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldBeInvalidBecauseDoesNotHaveAnAlunoWithThisAlunoId()
        {
            // Arrange
            var request = new UpdateAlunoRequest
            {
                AlunoId = 8,
                Nome = "Aluno Test",
                Email = "alunotest.com"
            };

            // Act
            var result = _validator.TestValidate(request);

            // Assert
            Assert.False(result.IsValid);
        }
    }
}
