using Loja.Application.Dto.Abstractions;
using Loja.Domain.Contracts;

namespace Loja.Application.Contracts;

public interface IBaseService<T> where T : IEntity
{
    Task<bool> Create(ICreateDto<T> obj);
    Task<List<T>> Get(IDto<T> dto);
    Task<T?> Get(int id);
    Task<bool> Update(IUpdateDto<T> obj);
    Task<bool> Delete(int id);
}