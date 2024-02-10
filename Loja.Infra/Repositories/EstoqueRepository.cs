using Loja.Domain.Contracts;
using Loja.Domain.Entities;
using Loja.Infra.Abstractions;
using Loja.Infra.Context;

namespace Loja.Infra.Repositories;

public class EstoqueRepository: BaseRepository<Estoque>, IEstoqueRepository
{
    public EstoqueRepository(LojaDbContext context) : base(context)
    {
    }
}