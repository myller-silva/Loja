using Loja.Domain.Contracts;
using Loja.Domain.Entities;
using Loja.Infra.Abstractions;
using Loja.Infra.Context;

namespace Loja.Infra.Repositories;

public class DescontoRepository:BaseRepository<Desconto>, IDescontoRepository
{
    public DescontoRepository(LojaDbContext context) : base(context)
    {
    }
}