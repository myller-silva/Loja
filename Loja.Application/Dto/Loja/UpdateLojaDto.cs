using Loja.Application.Dto.Abstractions;

namespace Loja.Application.Dto.Loja;

public class UpdateLojaDto: IUpdateDto<Domain.Entities.Loja>
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Endereco { get; set; } = null!;
}