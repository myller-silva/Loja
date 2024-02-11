using Loja.Application.Dto.Loja;
using Loja.Domain.Entities;

namespace Loja.Application.Contracts;

public interface ILojaService: IBaseService<Domain.Entities.Loja>
{
    
    Task<bool> Create(CreateLojaDto dto);
    Task<bool> Update(UpdateLojaDto dto);
    Task<Produto?> DescontoEmProdutoParaUsuario(int lojaId, int produtoId, int usuarioId);
}