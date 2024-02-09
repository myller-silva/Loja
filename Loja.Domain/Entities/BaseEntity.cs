using Loja.Domain.Contracts;

namespace Loja.Domain.Entities;

public abstract class BaseEntity: IEntity
{
    public int Id { get; set; }
}