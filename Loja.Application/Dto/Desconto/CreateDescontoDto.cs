using Loja.Application.Dto.Abstractions;

namespace Loja.Application.Dto.Desconto;

public class CreateDescontoDto: ICreateDto<Domain.Entities.Desconto>
{
    public double ValorDesconto { get; set; }
    public int ProdutoId { get; set; }
    public int UsuarioId { get; set; }
}