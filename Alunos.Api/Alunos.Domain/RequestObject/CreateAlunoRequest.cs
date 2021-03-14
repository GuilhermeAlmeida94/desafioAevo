using Alunos.Domain.Entities;
using MediatR;

namespace Alunos.Domain.RequestObject
{
    public class CreateAlunoRequest : IRequest<Aluno>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}