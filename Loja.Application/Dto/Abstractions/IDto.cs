using System.Linq.Expressions;

namespace Loja.Application.Dto.Abstractions;

public interface IDto<T>
{
    public Expression<Func<T, bool>> Filtro();
}
