using ApiApplication.Configuration;
using Data.Contexto;
using Infra.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;


builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentityConfiguration(configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.WebApiConfig(configuration);  
builder.Services.ResolveDependencies();

var app = builder.Build();




// CONFIGURE the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
