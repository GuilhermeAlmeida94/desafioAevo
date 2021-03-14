using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace Alunos.RequestHandlers
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRequestHandlers(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}