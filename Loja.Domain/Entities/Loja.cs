namespace Loja.Domain.Entities;

public class Loja: Entity
{
    public string Nome { get; set; } = null!;
    public string Endereco { get; set; } = null!;

    public List<Produto> Produtos { get; set; } = new();
}