using System.Linq.Expressions;
using Loja.Domain.Entities;

namespace Loja.Domain.Contracts;

public interface IBaseRepository<T> : IDisposable where T : BaseEntity
{
    Task<bool> Create(T type);
    Task<List<T>> Get(Expression<Func<T, bool>> predicate);
    Task<T?> Get(int id);
    Task<bool> Update(T type);
    Task<bool> Delete(int id);
}