using Loja.Domain.Contracts;

namespace Loja.Domain.Entities;

public class BaseEntity: IEntity
{
    public int Id { get; set; }
}