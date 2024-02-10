using Loja.Application.Dto.Abstractions;

namespace Loja.Application.Dto.Produto;

public class CreateProdutoDto: ICreateDto<Domain.Entities.Produto>
{
    public Domain.Entities.Produto Value { get; set; }
}