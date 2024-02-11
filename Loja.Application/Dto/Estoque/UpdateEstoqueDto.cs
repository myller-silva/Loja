using Loja.Application.Dto.Abstractions;

namespace Loja.Application.Dto.Estoque;

public class UpdateEstoqueDto: IUpdateDto<Domain.Entities.Estoque>
{
    public int Id { get; set; }
    public int Quantidade { get; set; }
    public int LojaId { get; set; }
    public int ProdutoId { get; set; }
}