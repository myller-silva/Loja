using Loja.Domain.Contracts;

namespace Loja.Application.Dto.Abstractions;

public interface IUpdateDto<T> where T: IEntity 
{ 
    int Id { get; set; }
}