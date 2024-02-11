using Loja.Application.Dto.Abstractions;

namespace Loja.Application.Dto.Usuario;

public class UpdateUsuarioDto : IUpdateDto<Domain.Entities.Usuario>
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public string? Email { get; set; }
    public string? Senha { get; set; }
}