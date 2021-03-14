using Alunos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace Alunos.Domain.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Aluno> Alunos { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        EntityEntry<Aluno> Entry(Aluno aluno);
    }
}