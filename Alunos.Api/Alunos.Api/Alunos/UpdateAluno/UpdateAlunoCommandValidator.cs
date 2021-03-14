using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Alunos.Domain.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Alunos.Api.Alunos.UpdateAluno
{
    public class UpdateAlunoCommandValidator: AbstractValidator<UpdateAlunoCommand>
    {
        private readonly IAppDbContext _context;

        public UpdateAlunoCommandValidator(IAppDbContext context)
        {
            _context = context;

            RuleFor(a => a.AlunoId)
                .MustAsync(ExistsAluno).WithMessage("O aluno com este id não existe.");

            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("O campo nome é obrigatório.")
                .MaximumLength(250).WithMessage("O campo nome deve ter no máximo 250 caracteres.");
            
            RuleFor(a => a.Email)
                .EmailAddress().WithMessage("O campo email não é válido.");
        }

        public async Task<bool> ExistsAluno(int AlunoId, CancellationToken cancellationToken)
        {
            return await _context.Alunos
                .AnyAsync(i => i.AlunoId == AlunoId);
        }
    }
}