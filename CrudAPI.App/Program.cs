using CrudAPI.Dados.Context;
using CrudAPI.Dados.Repositorio;
using CrudAPI.RegraNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//é a busca da minha string de conexão
string connString = builder.Configuration.GetConnectionString(
    "AzureDatabase") ?? "";

//Aqui estou definindo minha classe de contexto
builder.Services.AddDbContext<ContextDB>(options =>
{
    options.UseSqlServer(connString); //aqui estou passando minha string de conexão e definindo o Sql Server como banco de dados
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injeção de Depedência
builder.Services.AddScoped<ContextDB>();
builder.Services.AddScoped<IContaRepositorio, ContaRepositorio>();
builder.Services.AddScoped<IMovimentoContaRepositorio, MovimentoContaRepositorio>();
builder.Services.AddScoped<IPagamentoContaRepositorio, PagamentoContaRepositorio>();
builder.Services.AddScoped<IContaBancariaRepositorio, ContaBancariaRepositorio>();

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
