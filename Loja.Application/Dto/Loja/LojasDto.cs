using System.Linq.Expressions;
using Loja.Application.Dto.Abstractions;
using Loja.Core.Extensions;

namespace Loja.Application.Dto.Loja;

public class LojasDto : IDto<Domain.Entities.Loja>
{
    public string? Nome { get; set; }
    public string? Endereco { get; set; }
    
    public Expression<Func<Domain.Entities.Loja, bool>> Filtro()
    {
        Expression<Func<Domain.Entities.Loja, bool>> expression = x => true;

        if (!string.IsNullOrEmpty(Nome))
        {
            expression = expression.And(x => x.Nome == Nome);
        }

        if (!string.IsNullOrEmpty(Endereco))
        {
            expression = expression.And(x => x.Endereco == Endereco);
        }
 
        return expression;
    }
}