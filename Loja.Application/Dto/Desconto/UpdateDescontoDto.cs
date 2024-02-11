using Loja.Application.Dto.Abstractions;

namespace Loja.Application.Dto.Desconto;

public class UpdateDescontoDto: IUpdateDto<Domain.Entities.Desconto>
{
    public int Id { get; set; }
    public double ValorDesconto { get; set; }
    public int ProdutoId { get; set; }
    public int UsuarioId { get; set; }
}