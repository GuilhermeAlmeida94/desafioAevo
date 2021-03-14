using Alunos.Validators.Alunos;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Alunos.Domain.RequestObject;

namespace Alunos.Validators
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation();
            services.AddTransient<IValidator<CreateAlunoRequest>, CreateAlunoRequestValidator>();
            services.AddTransient<IValidator<UpdateAlunoRequest>, UpdateAlunoRequestValidator>();

            return services;
        }
    }
}