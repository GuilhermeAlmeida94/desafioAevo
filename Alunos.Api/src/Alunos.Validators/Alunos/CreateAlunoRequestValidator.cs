using System.Threading;
using System.Threading.Tasks;
using Alunos.Domain.Interfaces;
using Alunos.Domain.RequestObject;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Alunos.Validators.Alunos
{
    public class CreateAlunoRequestValidator : AbstractValidator<CreateAlunoRequest>
    {
        private readonly IAppDbContext _context;

        public CreateAlunoRequestValidator(IAppDbContext context)
        {
            _context = context;

            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("O campo nome é obrigatório.")
                .MaximumLength(250).WithMessage("O campo nome deve ter no máximo 250 caracteres.")
                .MustAsync(BeUniqueNome).WithMessage("Já existe um aluno com o nome especificado.");
            
            RuleFor(a => a.Email)
                .EmailAddress().WithMessage("O campo email não é válido.");
        }

        public async Task<bool> BeUniqueNome(string Nome, CancellationToken cancellationToken)
        {
            return await _context.Alunos
                .AllAsync(n => n.Nome != Nome);
        }
    }
}