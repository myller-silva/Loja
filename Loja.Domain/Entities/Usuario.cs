namespace Loja.Domain.Entities;

public class Usuario:Entity
{
    public string Nome { get; set; } = null!;
    public string Cpf { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Senha { get; set; } = null!;

    public virtual List<Desconto> Descontos { get; set; } = new();
}