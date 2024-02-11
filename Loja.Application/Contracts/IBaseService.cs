using Loja.Application.Dto.Abstractions;
using Loja.Domain.Contracts;

namespace Loja.Application.Contracts;

public interface IBaseService<T> where T : IEntity
{
    Task<List<T>> Get(IDto<T> dto);
    Task<T?> Get(int id);
    Task<bool> Delete(int id);
}