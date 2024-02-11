using Loja.Application.Dto.Usuario;
using Loja.Domain.Entities;

namespace Loja.Application.Contracts;

public interface IUsuarioService: IBaseService<Usuario>
{
    Task<bool> Create(CreateUsuarioDto dto);
    Task<bool> Update(UpdateUsuarioDto dto);
}