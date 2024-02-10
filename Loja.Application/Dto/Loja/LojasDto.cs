using System.Linq.Expressions;
using Loja.Application.Dto.Abstractions;

namespace Loja.Application.Dto.Loja;

public class LojasDto : IDto<Domain.Entities.Loja>
{
    public string? Nome { get; set; }
    public string? Endereco { get; set; }
    public Expression<Func<Domain.Entities.Loja, bool>> Filtro()
    {
        return x => true;
    }
}