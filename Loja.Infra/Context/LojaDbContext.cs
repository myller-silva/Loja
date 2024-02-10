using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infra.Context;

public class LojaDbContext: DbContext
{

    public DbSet<Domain.Entities.Loja> Lojas { get; set; }
    public DbSet<Domain.Entities.Produto> Produtos { get; set; }
    public DbSet<Domain.Entities.Usuario> Usuarios { get; set; }
    public DbSet<Domain.Entities.Desconto> Descontos { get; set; }
    public DbSet<Domain.Entities.Estoque> Estoques { get; set; }
    
    public LojaDbContext(DbContextOptions<LojaDbContext> options): base(options)
    { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Vai aplicar uma configuração padrão para as propriedades que não forem mapeadas.
        // Setando como varchar(100)
        // Deve vir antes do *modelBuilder.ApplyConfigurationsFromAssembly()*
        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                     e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)");
        
        // Vai aplicar os mappings (Modelo -> Banco) usando reflection.
        // Os mappings ficam na pasta Mappings
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public async Task<bool> Commit()
    {
        return await SaveChangesAsync() > 0;
    }


}