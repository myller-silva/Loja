using Loja.Application.Dto.Abstractions;

namespace Loja.Application.Dto.Usuario;

public class CreateUsuarioDto: ICreateDto<Domain.Entities.Usuario>
{
    public Domain.Entities.Usuario Value { get; set; }
}