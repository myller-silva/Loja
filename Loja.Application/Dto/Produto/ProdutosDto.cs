using System.Linq.Expressions;
using Loja.Application.Dto.Abstractions;
using Loja.Core.Extensions;

namespace Loja.Application.Dto.Produto;

public class ProdutosDto: IDto<Domain.Entities.Produto>
{
    public string? Nome { get; set; } 
    public int? LojaId { get; set; }
    public string? LojaNome { get; set; }
    
    public Expression<Func<Domain.Entities.Produto, bool>> Filtro()
    {
        
        Expression<Func<Domain.Entities.Produto, bool>> expression = x => true;

        if (!string.IsNullOrEmpty(Nome))
        {
            expression = expression.And(x => x.Nome == Nome);
        }

        if (LojaId.HasValue)
        {
            expression = expression.And(x => x.Estoques.Any(y=>y.LojaId == LojaId));
        }
        
        if (!string.IsNullOrEmpty(LojaNome))
        {
            expression = expression.And(x => x.Estoques.Any(y=>y.Loja.Nome==LojaNome));
        }
 
        return expression;
    }
}