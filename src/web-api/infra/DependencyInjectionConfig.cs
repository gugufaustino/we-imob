using Microsoft.Extensions.DependencyInjection;

namespace Infra.Configuration
{
	public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //services.AddScoped<AppDbContext>();
            //services.AddScoped<IBroadcaster, Broadcaster>();

            //services.AddScoped<IUsuarioService, UsuarioService>();
            //services.AddScoped<IEnderecoService, EnderecoService>();
            //services.AddScoped<IModeloService, ModeloService>();
            //services.AddScoped<IAgenciaService, AgenciaService>();

            //services.AddScoped<IValidator<Usuario>, UsuarioValidation>();
            //services.AddScoped<IValidator<AgenciaEmpresa>, AgenciaEmpresaValidation>();
            //services.AddScoped<IValidator<Modelo>, ModeloValidation>();



            //services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            ////services.AddScoped<IUsuarioRepository, UsuarioRepositoryFake>();
            //services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            //services.AddScoped<IModeloRepository, ModeloRepository>();
            //services.AddScoped<IAgenciaRepository, AgenciaRepository>();
            //services.AddScoped<IAgenciaEmpresaRepository, AgenciaEmpresaRepository>();

            //services.AddScoped<IUser, User>();
            return services;
        }
    }

}