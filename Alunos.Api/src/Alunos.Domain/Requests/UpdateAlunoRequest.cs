using MediatR;

namespace Alunos.Domain.Requests
{
    public class UpdateAlunoRequest : IRequest
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}