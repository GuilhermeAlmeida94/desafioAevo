using MediatR;

namespace Alunos.Domain.RequestObject
{
    public class UpdateAlunoRequest : IRequest
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}