using Loja.Application.Dto.Abstractions;

namespace Loja.Application.Dto.Produto;

public class UpdateProdutoDto: IUpdateDto<Domain.Entities.Produto>
{
    
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public double Preco { get; set; }
    public string? Descricao { get; set; }
}