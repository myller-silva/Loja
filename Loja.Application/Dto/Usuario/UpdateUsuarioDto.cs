using Loja.Application.Dto.Abstractions;

namespace Loja.Application.Dto.Usuario;

public class UpdateUsuarioDto: IUpdateDto<Domain.Entities.Usuario>
{
    public Domain.Entities.Usuario Value { get; set; }
}