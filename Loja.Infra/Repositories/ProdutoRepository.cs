using Loja.Domain.Contracts;
using Loja.Domain.Entities;
using Loja.Infra.Abstractions;
using Loja.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infra.Repositories;

public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
{
    public ProdutoRepository(LojaDbContext context) : base(context)
    {
    }

    public async Task<Produto?> DescontoEmProdutoParaUsuario(int lojaId, int produtoId, int usuarioId)
    {
        var query = Context.Produtos.AsQueryable()
            .Include(x => x.Descontos)
            .Where(x => x.Id == produtoId)
            .Where(x => x.Descontos.Any(y => y.UsuarioId == usuarioId));
        return await query.FirstOrDefaultAsync();
    }
}