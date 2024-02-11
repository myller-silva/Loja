using System.Text.Json.Serialization;
using Loja.Application.Contracts;
using Loja.Application.Services;
using Loja.Domain.Contracts;
using Loja.Infra.Context;
using Loja.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configuração do DbContext
builder.Services.AddDbContext<LojaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Services
builder
    .Services
    .AddScoped<IUsuarioRepository, UsuarioRepository>()
    .AddScoped<IDescontoRepository, DescontoRepository>()
    .AddScoped<ILojaRepository, LojaRepository>()
    .AddScoped<IProdutoRepository, ProdutoRepository>()
    .AddScoped<IEstoqueRepository, EstoqueRepository>();

builder
    .Services
    .AddScoped<IUsuarioService, UsuarioService>()
    .AddScoped<IDescontoService, DescontoService>()
    .AddScoped<ILojaService, LojaService>()
    .AddScoped<IProdutoService, ProdutoService>()
    .AddScoped<IEstoqueService, EstoqueService>();

// Configuração do Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Loja API",
        Version = "v1",
        Description = "API de Gerenciamento de Loja",
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();// Configurações adicionais do Swagger UI
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Loja API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();