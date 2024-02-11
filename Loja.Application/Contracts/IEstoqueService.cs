using Loja.Application.Dto.Estoque;
using Loja.Domain.Entities;

namespace Loja.Application.Contracts;

public interface IEstoqueService: IBaseService<Estoque>
{
    
    Task<bool> Create(CreateEstoqueDto dto);
    Task<bool> Update(UpdateEstoqueDto dto);
}