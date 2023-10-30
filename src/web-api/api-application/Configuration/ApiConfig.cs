using ApiApplication.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ApiApplication.Configuration
{
	public static class ApiConfig
	{
		public static IServiceCollection WebApiConfig(this IServiceCollection services, IConfiguration configuration)
		{

			var appSettingsSection = configuration.GetSection("AppSettings");
			services.Configure<AppSettings>(appSettingsSection);
			var corsOrigins = appSettingsSection.Get<AppSettings>()!.CorsOrigins;

			services.AddControllers();
			services.AddHttpContextAccessor();
			services.Configure<ApiBehaviorOptions>(option =>
			{
				option.SuppressModelStateInvalidFilter = true;
			});

			services.AddCors(options =>
			{
				options.AddPolicy("Development",
							builder => builder.AllowAnyOrigin()
												.AllowAnyMethod()
												.AllowAnyHeader());
				options.AddPolicy("Staging",
							builder => builder.WithOrigins(corsOrigins)
												.SetIsOriginAllowedToAllowWildcardSubdomains()
												.AllowAnyMethod()
												.AllowAnyHeader());

				options.AddPolicy("Production",
						   builder => builder.WithOrigins(corsOrigins)
											 .SetIsOriginAllowedToAllowWildcardSubdomains()
											 .AllowAnyMethod()
											 .AllowAnyHeader());

			});

			services.AddOpenApiSwagger();

			return services;
		}

		private static void AddOpenApiSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Description = @"JWT Authorization header using the Bearer scheme.
						Enter 'Bearer' [space] and then your token in the text input below. Example: 'Bearer 12345abcdef'",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer"
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
					{new OpenApiSecurityScheme {
						Reference = new OpenApiReference
						  {
							Type = ReferenceType.SecurityScheme,
							Id = "Bearer"
						  },
						  Scheme = "oauth2",
						  Name = "Bearer",
						  In = ParameterLocation.Header,

						},
						new List<string>()
					  }
					});

			});
		}

		public static IApplicationBuilder UseMvcConfiguration(this IApplicationBuilder app)
		{

			app.UseHttpsRedirection();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseStaticFiles();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				//	endpoints.MapHealthChecks();

			});


			//app.MapControllers();


			return app;
		}


	}
}
