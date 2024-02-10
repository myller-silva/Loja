using Loja.Domain.Contracts;
using Loja.Domain.Entities;
using Loja.Infra.Abstractions;
using Loja.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infra.Repositories;

public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(LojaDbContext context) : base(context)
    {
    }

    public async Task<Usuario?> ObterPorEmail(string email)
    {
        var query = Context.Usuarios.AsQueryable();
        return await query.Where(x => x.Email == email).FirstOrDefaultAsync();
    }
}
