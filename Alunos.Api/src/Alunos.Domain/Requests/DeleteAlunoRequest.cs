using MediatR;

namespace Alunos.Domain.Requests
{
    public class DeleteAlunoRequest : IRequest
    {
        public int AlunoId { get; set; }
    }
}