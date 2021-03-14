using System.Threading;
using System.Threading.Tasks;
using Alunos.Domain.Interfaces;
using MediatR;

namespace Alunos.Api.Alunos.DeleteAluno
{
    public class DeleteAlunoCommand : IRequest
    {
        public int AlunoId { get; set; }
    }

    public class DeleteAlunoCommandHandler : IRequestHandler<DeleteAlunoCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteAlunoCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAlunoCommand command, CancellationToken cancellationToken)
        {
            var aluno = await _context.Alunos.FindAsync(command.AlunoId);
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}