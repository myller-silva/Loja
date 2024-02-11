using System.Linq.Expressions;
using Loja.Domain.Contracts;
using Loja.Domain.Entities;
using Loja.Infra.Abstractions;
using Loja.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infra.Repositories;

public class EstoqueRepository: BaseRepository<Estoque>, IEstoqueRepository
{
    public EstoqueRepository(LojaDbContext context) : base(context)
    {
    }
    
    public new async Task<List<Estoque>> Get(Expression<Func<Estoque, bool>> predicate)
    {
        var queryable = Context.Estoques.AsQueryable()
            .Include(x => x.Produto)
            .Include(x => x.Loja)
            .Where(predicate);
        return await queryable.ToListAsync();
    }

    public new async Task<Estoque?> Get(int id)
    {
        var queryable = Context.Estoques.AsQueryable()
            .Include(x=>x.Loja)
            .Include(x=>x.Produto)
            .Where(x=>x!.Id == id);
        return await queryable.FirstOrDefaultAsync();
    }
}