using Loja.Application.Dto.Abstractions;

namespace Loja.Application.Dto.Produto;

public class UpdateProdutoDto: IUpdateDto<Domain.Entities.Produto>
{
    public Domain.Entities.Produto Value { get; set; }
}