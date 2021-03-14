using Alunos.Domain.Requests;
using Alunos.Domain.Entities;
using AutoMapper;

namespace Alunos.RequestHandlers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CreateAlunoRequest, Aluno>();
            CreateMap<UpdateAlunoRequest, Aluno>();
        }
    }
}