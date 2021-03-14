using System.Threading;
using System.Threading.Tasks;
using Alunos.Domain.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Alunos.Api.Alunos.CreateAluno
{
    public class CreateAlunoCommandValidator : AbstractValidator<CreateAlunoCommand>
    {
        private readonly IAppDbContext _context;

        public CreateAlunoCommandValidator(IAppDbContext context)
        {
            _context = context;

            RuleFor(v => v.Nome)
                .NotEmpty().WithMessage("O campo nome é obrigatório.")
                .MaximumLength(250).WithMessage("O campo nome deve ter no máximo 250 caracteres.")
                .MustAsync(BeUniqueNome).WithMessage("Já existe um aluno com o nome especificado.");
            
            RuleFor(v => v.Email)
                .EmailAddress().WithMessage("O campo email não é válido.");
        }

        public async Task<bool> BeUniqueNome(string Nome, CancellationToken cancellationToken)
        {
            return await _context.Alunos
                .AllAsync(l => l.Nome != Nome);
        }
    }
}