using Alunos.Domain.Entities;
using MediatR;

namespace Alunos.Domain.Requests
{
    public class CreateAlunoRequest : IRequest<Aluno>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}