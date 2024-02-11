using Loja.Application.Dto.Abstractions;

namespace Loja.Application.Dto.Estoque;

public class CreateEstoqueDto: ICreateDto<Domain.Entities.Estoque>
{
    
    public int Quantidade { get; set; }
    public int LojaId { get; set; }
    public int ProdutoId { get; set; }
}