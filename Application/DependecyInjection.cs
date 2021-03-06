using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Application.Common.Behaviour;
using Application.Common.Interface;
using Application.Services;
using AutoMapper;
using Application.Common.Mappings;

namespace Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
