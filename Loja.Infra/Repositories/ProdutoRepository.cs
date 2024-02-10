using Loja.Domain.Contracts;
using Loja.Domain.Entities;
using Loja.Infra.Abstractions;
using Loja.Infra.Context;

namespace Loja.Infra.Repositories;

public class ProdutoRepository: BaseRepository<Produto>, IProdutoRepository
{
    public ProdutoRepository(LojaDbContext context) : base(context)
    {
    }
}