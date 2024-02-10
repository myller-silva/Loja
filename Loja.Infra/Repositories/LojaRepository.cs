using Loja.Domain.Contracts;
using Loja.Infra.Abstractions;
using Loja.Infra.Context;

namespace Loja.Infra.Repositories;

public class LojaRepository:BaseRepository<Domain.Entities.Loja>, ILojaRepository
{
    public LojaRepository(LojaDbContext context) : base(context)
    {
    }
}