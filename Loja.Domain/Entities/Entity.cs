using FluentValidation.Results;

namespace Loja.Domain.Entities;

public class Entity
{
    public virtual bool Validar(out ValidationResult validationResult)
    {
        validationResult = new ValidationResult();
        return validationResult.IsValid;
    }
}