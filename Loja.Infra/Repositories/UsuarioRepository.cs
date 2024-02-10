using Loja.Domain.Contracts;
using Loja.Domain.Entities;
using Loja.Infra.Abstractions;
using Loja.Infra.Context;

namespace Loja.Infra.Repositories;

public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(LojaDbContext context) : base(context)
    {
    }

    public async Task<Usuario?> ObterPorEmail(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> VerificarSeEmailEmUso(string email)
    {
        throw new NotImplementedException();
    }
}
