using Loja.Application.Contracts;
using Loja.Application.Services;
using Loja.Domain.Contracts;
using Loja.Infra.Context;
using Loja.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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
    .AddScoped<IProdutoRepository, ProdutoRepository>();

builder
    .Services
    .AddScoped<IUsuarioService, UsuarioService>()
    .AddScoped<IDescontoService, DescontoService>()
    .AddScoped<ILojaService, LojaService>()
    .AddScoped<IProdutoService, ProdutoService>();


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