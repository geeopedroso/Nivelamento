using MediatR;
using Questao5.Domain.Interfaces;
using Questao5.Domain.Interfaces.Services;
using Questao5.Domain.Service.ContaCorrenteService;
using Questao5.Domain.Service.Movimento;
using Questao5.Domain.Service.Saldo;
using Questao5.Infrastructure.Database.CommandStore.Movimento;
using Questao5.Infrastructure.Database.QueryStore.ContaCorrente;
using Questao5.Infrastructure.Database.QueryStore.Saldo;
using Questao5.Infrastructure.Services.Midleware;
using Questao5.Infrastructure.Sqlite;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// sqlite
builder.Services.AddSingleton(new DatabaseConfig { Name = builder.Configuration.GetValue<string>("DatabaseName", "Data Source=database.sqlite") });
builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();

builder.Services.AddScoped<ISaldoService, SaldoService>();
builder.Services.AddScoped<IMovimentoService, MovimentoService>();
builder.Services.AddScoped<IContaCorrenteService, ContaCorrenteService>();

builder.Services.AddScoped<ISaldoQueryStore, SaldoQueryStore>();
builder.Services.AddScoped<IMovimentoCommandStore, MovimentoCommandStore>();
builder.Services.AddScoped<IContaCorrenteQueryStore, ContaCorrenteQueryStore>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMidleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// sqlite
#pragma warning disable CS8602 // Dereference of a possibly null reference.
app.Services.GetService<IDatabaseBootstrap>().Setup();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

app.Run();

// Informações úteis:
// Tipos do Sqlite - https://www.sqlite.org/datatype3.html


