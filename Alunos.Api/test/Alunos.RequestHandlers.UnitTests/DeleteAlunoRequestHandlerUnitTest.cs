using Alunos.Domain.Entities;
using Alunos.Domain.Interfaces;
using Alunos.Domain.Requests;
using Alunos.RequestHandlers.Alunos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading;
using Xunit;

namespace Alunos.RequestHandlers.UnitTests
{
    public class DeleteAlunoRequestHandlerUnitTest
    {
        Mock<DbSet<Aluno>> _mockSet;
        Mock<IAppDbContext> _mockContext;

        public DeleteAlunoRequestHandlerUnitTest()
        {
            _mockSet = new Mock<DbSet<Aluno>>();
            _mockContext = new Mock<IAppDbContext>();
            _mockContext.Setup(m => m.Alunos).Returns(_mockSet.Object);
        }
        [Fact]
        public async void DeleteAluno()
        {
            // Arrange
            var requestHandler = new DeleteAlunoRequestHandler(_mockContext.Object);
            var request = new DeleteAlunoRequest
            {
                AlunoId = 1
            };

            // Act
            var result = await requestHandler.Handle(request, CancellationToken.None);

            // Assert
            _mockSet.Verify(m => m.Remove(It.IsAny<Aluno>()), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(CancellationToken.None), Times.Once());
        }
    }
}
