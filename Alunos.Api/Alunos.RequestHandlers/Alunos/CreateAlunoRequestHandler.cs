using System.Threading;
using System.Threading.Tasks;
using Alunos.Domain.Interfaces;
using Alunos.Domain.Entities;
using MediatR;
using AutoMapper;
using Alunos.Domain.RequestObject;

namespace Alunos.RequestHandlers.Alunos
{
    public class CreateAlunoRequestHandler : IRequestHandler<CreateAlunoRequest, Aluno>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateAlunoRequestHandler(IAppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Aluno> Handle(CreateAlunoRequest command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Aluno>(command);

            _context.Alunos.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}