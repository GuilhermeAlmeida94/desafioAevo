using Alunos.Api.Alunos.CreateAluno;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Alunos.Api.DependencyInjection
{
    public static class ValidatorDependencyInjection
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation();    
            services.AddTransient<IValidator<CreateAlunoCommand>, CreateAlunoCommandValidator>();

            return services;
        }
    }
}