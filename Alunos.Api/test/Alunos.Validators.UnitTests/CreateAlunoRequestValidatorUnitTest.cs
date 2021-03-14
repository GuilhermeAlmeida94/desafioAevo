using Alunos.Validators.Alunos;
using Alunos.Domain.Requests;
using Xunit;
using FluentValidation.TestHelper;
using Alunos.Domain.Interfaces;

namespace Alunos.Validators.UnitTests
{
    public class CreateAlunoRequestValidatorUnitTest
    {
        CreateAlunoRequestValidator _validator;
        public CreateAlunoRequestValidatorUnitTest()
        {
            var context = FakeAppDbContext.Build();
            _validator = new CreateAlunoRequestValidator(context);
        }

        [Fact]
        public void ShouldBeValid()
        {
            // Arrange
            var request = new CreateAlunoRequest
            {
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
            var request = new CreateAlunoRequest
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
            var request = new CreateAlunoRequest
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
            var request = new CreateAlunoRequest
            {
                Nome = "Aluno Test",
                Email = "alunotest.com"
            };

            // Act
            var result = _validator.TestValidate(request);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldBeInvalidBecauseDoesHaveAnotherAlunoWithSameNome()
        {
            // Arrange
            var request = new CreateAlunoRequest
            {
                Nome = "Aluno 1",
                Email = "aluno@test.com"
            };

            // Act
            var result = _validator.TestValidate(request);

            // Assert
            Assert.False(result.IsValid);
        }
    }
}
