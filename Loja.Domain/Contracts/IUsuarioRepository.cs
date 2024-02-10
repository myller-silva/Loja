using Loja.Domain.Entities;

namespace Loja.Domain.Contracts;


public interface IUsuarioRepository : IBaseRepository<Usuario>
{
    Task<Usuario?> ObterPorEmail(string email);
}
