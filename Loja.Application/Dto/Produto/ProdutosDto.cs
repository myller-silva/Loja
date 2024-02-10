using System.Linq.Expressions;
using Loja.Application.Dto.Abstractions;

namespace Loja.Application.Dto.Produto;

public class ProdutosDto: IDto<Domain.Entities.Produto>
{
    public Expression<Func<Domain.Entities.Produto, bool>> Filtro()
    {
        return x => true;
    }
}