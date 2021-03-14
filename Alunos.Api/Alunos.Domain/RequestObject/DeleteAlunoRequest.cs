using MediatR;

namespace Alunos.Domain.RequestObject
{
    public class DeleteAlunoRequest : IRequest
    {
        public int AlunoId { get; set; }
    }
}