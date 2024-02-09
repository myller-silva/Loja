using FluentValidation.Results;

namespace Loja.Domain.Entities;

public abstract class Entity: BaseEntity
{
    public virtual bool Validar(out ValidationResult validationResult)
    {
        validationResult = new ValidationResult();
        return validationResult.IsValid;
    }
}