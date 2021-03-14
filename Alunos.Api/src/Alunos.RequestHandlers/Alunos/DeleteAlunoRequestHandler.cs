using System.Threading;
using System.Threading.Tasks;
using Alunos.Domain.Interfaces;
using Alunos.Domain.Requests;
using MediatR;

namespace Alunos.RequestHandlers.Alunos
{
    public class DeleteAlunoRequestHandler : IRequestHandler<DeleteAlunoRequest>
    {
        private readonly IAppDbContext _context;

        public DeleteAlunoRequestHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAlunoRequest command, CancellationToken cancellationToken)
        {
            var aluno = await _context.Alunos.FindAsync(command.AlunoId);
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}