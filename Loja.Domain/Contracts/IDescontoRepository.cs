using Loja.Domain.Entities;

namespace Loja.Domain.Contracts;

public interface IDescontoRepository: IBaseRepository<Desconto>
{
    Task<List<Desconto>> ObterDescontosCliente(int lojaId, int usuarioId);
}