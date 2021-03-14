using System.Threading;
using System.Threading.Tasks;
using Alunos.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Alunos.Domain.Interfaces;
using Alunos.Domain.Requests;

namespace Alunos.RequestHandlers.Alunos
{
    public class UpdateAlunoRequestHandler : IRequestHandler<UpdateAlunoRequest>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateAlunoRequestHandler(IAppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Unit> Handle(UpdateAlunoRequest command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Aluno>(command);

            _context.SetModified(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}