using System.Threading;
using System.Threading.Tasks;
using Alunos.Domain.Interfaces;
using Alunos.Domain.Requests;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Alunos.Validators.Alunos
{
    public class UpdateAlunoRequestValidator: AbstractValidator<UpdateAlunoRequest>
    {
        private readonly IAppDbContext _context;

        public UpdateAlunoRequestValidator(IAppDbContext context)
        {
            _context = context;

            RuleFor(a => a.AlunoId)
                .NotEmpty().WithMessage("O campo AlunoId é obrigatório.")
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