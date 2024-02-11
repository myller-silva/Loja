using Loja.Domain.Contracts;
using Loja.Domain.Entities;
using Loja.Infra.Abstractions;
using Loja.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infra.Repositories;

public class DescontoRepository : BaseRepository<Desconto>, IDescontoRepository
{
    public DescontoRepository(LojaDbContext context) : base(context)
    {
    }

    public async Task<List<Desconto>> ObterDescontosCliente(int lojaId, int usuarioId)
    {
        var query = Context.Descontos
            .AsQueryable()
            .Include(x => x.Produto)
            .ThenInclude(p => p!.Estoques);

        return await query
            .Where(x => x.UsuarioId == usuarioId)
            .Where(x => x.Produto!.Estoques.Any(e => e.LojaId == lojaId))
            .ToListAsync();
    }
}