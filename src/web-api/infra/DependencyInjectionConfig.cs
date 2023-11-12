using Domain.Interface.Repository;
using Domain.Interface.Services;
using Data.Contexto;
using Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Domain.Interface;
using Domain.Identity;
using Domain.Notifications;
using FluentValidation;
using Domain.Models;
using Business.Services.Validations;

namespace Infra.Configuration
{
	public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
             services.AddScoped<AppDbContext>();
             services.AddScoped<IBroadcaster, Broadcaster>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            //services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IOrganizacaoService, OrganizacaoService>();

            services.AddScoped<IValidator<Usuario>, UsuarioValidation>();
            services.AddScoped<IValidator<Empresa>, EmpresaValidation>();


            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            ////services.AddScoped<IUsuarioRepository, UsuarioRepositoryFake>();
            //services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IOrganizacaoRepository, OrganizacaoRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();

            services.AddScoped<IUser, User>();
            return services;
        }
    }

}