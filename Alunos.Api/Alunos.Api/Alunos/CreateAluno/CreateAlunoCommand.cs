using System.Threading;
using System.Threading.Tasks;
using Alunos.Domain.Interfaces;
using Alunos.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Alunos.Api.Alunos.CreateAluno
{
    public class CreateAlunoCommand : IRequest<ActionResult<Aluno>>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }

    public class CreateAlunoCommandHandler : IRequestHandler<CreateAlunoCommand, ActionResult<Aluno>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateAlunoCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ActionResult<Aluno>> Handle(CreateAlunoCommand command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Aluno>(command);

            _context.Alunos.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}