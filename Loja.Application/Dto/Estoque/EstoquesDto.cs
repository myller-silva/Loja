using System.Linq.Expressions;
using Loja.Application.Dto.Abstractions;
using Loja.Core.Extensions;

namespace Loja.Application.Dto.Estoque;

public class EstoquesDto: IDto<Domain.Entities.Estoque>
{
    public int? LojaId { get; set; }
    public int? ProdutoId { get; set; }
    
    public Expression<Func<Domain.Entities.Estoque, bool>> Filtro()
    {
        Expression<Func<Domain.Entities.Estoque, bool>> expression = x => true;
        if (LojaId.HasValue)
        {
            expression = expression.And(x=>x.LojaId==LojaId);
        }

        if (ProdutoId.HasValue)
        {
            expression = expression.And(x=>x.ProdutoId==ProdutoId);
        }
        
        return expression;
    }
}