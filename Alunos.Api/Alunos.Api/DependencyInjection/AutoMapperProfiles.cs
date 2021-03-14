using Alunos.Api.Alunos.CreateAluno;
using Alunos.Domain.Entities;
using AutoMapper;

namespace Alunos.Api.DependencyInjection
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CreateAlunoCommand, Aluno>();
        }
    }
}