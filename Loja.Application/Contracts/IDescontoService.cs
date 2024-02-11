using Loja.Application.Dto.Desconto;
using Loja.Domain.Entities;

namespace Loja.Application.Contracts;

public interface IDescontoService: IBaseService<Desconto>
{
    
    Task<bool> Create(CreateDescontoDto dto);
    Task<bool> Update(UpdateDescontoDto dto);
    Task<List<Desconto>> ObterDescontosCliente(int lojaId, int usuarioId);
}