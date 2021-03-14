using System.Threading;
using System.Threading.Tasks;
using Alunos.Domain.Interfaces;
using Alunos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Alunos.Infrastructure.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Aluno> Alunos { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
