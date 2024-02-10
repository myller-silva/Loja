using Loja.Application.Dto.Abstractions;

namespace Loja.Application.Dto.Loja;

public class UpdateLojaDto: IUpdateDto<Domain.Entities.Loja>
{
    public Domain.Entities.Loja Value { get; set; }
}