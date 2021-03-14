using Alunos.Domain.Entities;
using Alunos.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alunos.Validators.UnitTests
{
    internal static class FakeAppDbContext
    {
        internal static AppDbContext Build()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dbContext = new AppDbContext(options); dbContext.Alunos.AddRange(GetFakeData().AsQueryable());
            dbContext.SaveChanges();
            return dbContext;
        }
        private static List<Aluno> GetFakeData()
        {
            var alunos = new List<Aluno>
            {
                new Aluno { AlunoId = 1, Nome = "Aluno 1", Email = "aluno1@test.com"},
                new Aluno { AlunoId = 2, Nome = "Aluno 2", Email = "aluno2@test.com"},
                new Aluno { AlunoId = 3, Nome = "Aluno 3", Email = "aluno3@test.com"}
            };
            
            return alunos;
        }
    }
}
