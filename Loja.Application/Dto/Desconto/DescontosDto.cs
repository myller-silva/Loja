using System.Linq.Expressions;
using Loja.Application.Dto.Abstractions;
using Loja.Core.Extensions;

namespace Loja.Application.Dto.Desconto;

public class DescontosDto: IDto<Domain.Entities.Desconto>
{
    public double? ValorDescontoSuperior { get; set; }
    public double? ValorDescontoInferior { get; set; }
    public int? ProdutoId { get; set; }
    public string? ProdutoNome { get; set; }
    public int? UsuarioId { get; set; }
    public string? UsuarioNome { get; set; }
    
    public Expression<Func<Domain.Entities.Desconto, bool>> Filtro()
    {
        Expression<Func<Domain.Entities.Desconto, bool>> expression = x => true;
        if (ValorDescontoInferior.HasValue)
        {
            expression = expression.And(x => ValorDescontoInferior <= x.ValorDesconto );
        }
        
        if (ValorDescontoSuperior.HasValue)
        {
            expression = expression.And(x => x.ValorDesconto <= ValorDescontoSuperior);
        }

        if (ProdutoId.HasValue)
        {
            expression = expression.And(x => x.ProdutoId == ProdutoId);
        }

        if (!string.IsNullOrEmpty(ProdutoNome))
        {
            expression = expression.And(x => x.Produto!.Nome == ProdutoNome);
        }
        if (UsuarioId.HasValue)
        {
            expression = expression.And(x => x.UsuarioId == UsuarioId);
        }

        if (!string.IsNullOrEmpty(UsuarioNome))
        {
            expression = expression.And(x => x.Usuario!.Nome == UsuarioNome);
        }
        return expression;
    }
}