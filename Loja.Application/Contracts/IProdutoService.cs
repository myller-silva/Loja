using Loja.Application.Dto.Produto;
using Loja.Domain.Entities;

namespace Loja.Application.Contracts;

public interface IProdutoService: IBaseService<Produto>
{
    
    Task<bool> Create(CreateProdutoDto dto);
    Task<bool> Update(UpdateProdutoDto dto);
}