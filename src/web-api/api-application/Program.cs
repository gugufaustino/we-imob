using Data.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;

var builder = WebApplication.CreateBuilder(args);

IConfiguration Configuration = builder.Configuration;

//var cbuilder = new ConfigurationBuilder()
//					.AddJsonFile("appsettings.json", true, true)
//					.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
//					.AddEnvironmentVariables();
//Configuration = cbuilder.Build();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
