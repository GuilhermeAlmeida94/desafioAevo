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
    public class CreateAlunoRequestHandlerUnitTest
    {
        Mock<DbSet<Aluno>> _mockSet;
        Mock<IAppDbContext> _mockContext;
        IMapper _mapper;
        public CreateAlunoRequestHandlerUnitTest()
        {
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new AutoMapperProfiles());
            });

            _mapper = config.CreateMapper();

            _mockSet = new Mock<DbSet<Aluno>>();
            _mockContext = new Mock<IAppDbContext>();
            _mockContext.Setup(m => m.Alunos).Returns(_mockSet.Object);
        }
        [Fact]
        public async void CreateAluno()
        {
            // Arrange
            var requestHandler = new CreateAlunoRequestHandler(_mockContext.Object, _mapper);
            var request = new CreateAlunoRequest
            {
                Nome = "Aluno Test",
                Email = "aluno1@test.com"
            };

            // Act
            var result = await requestHandler.Handle(request, CancellationToken.None);

            // Assert
            _mockSet.Verify(m => m.Add(It.IsAny<Aluno>()), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(CancellationToken.None), Times.Once());
        }
    }
}
