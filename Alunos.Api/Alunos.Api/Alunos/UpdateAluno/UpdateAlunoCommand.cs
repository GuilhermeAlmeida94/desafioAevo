using System.Threading;
using System.Threading.Tasks;
using Alunos.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Alunos.Domain.Interfaces;
using System.Linq;

namespace Alunos.Api.Alunos.UpdateAluno
{
    public class UpdateAlunoCommand: IRequest
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }

    public class UpdateAlunoCommandHandler : IRequestHandler<UpdateAlunoCommand>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateAlunoCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Unit> Handle(UpdateAlunoCommand command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Aluno>(command);

            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private bool AlunoExists(int id)
        {
            return _context.Alunos.Any(e => e.AlunoId == id);
        }
    }
}